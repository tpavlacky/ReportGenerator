﻿using System;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using ReportGenerator.Model;
using DevExpress.XtraTreeList;
using System.Drawing;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using ReportGenerator.DataProviders.TFS;
using ReportGenerator.DataProviders.TFS.TFSTestSuiteDataProvider;
using ReportGenerator.Settings;
using ReportGenerator.UIComponents.DXComponents.MessageBox;
using ReportGenerator.UIComponents.DXComponents.OverlayForm;

namespace ReportGenerator
{
	public partial class ReportGeneratorMainForm : RibbonForm
	{
		private readonly IDocXBuilderFactory _docXBuilderFactory = new DocXBuilderFactory();
		//private readonly ITestSuiteForReportProvider _testSuiteForReportProvider = new DummyTestSuiteForReportProvider();
		//private readonly ITestSuiteForReportProvider _testSuiteForReportProvider = new TFSPlanTestSuiteProvider();
		private readonly IReportItemsProvider _testPlanProvider = new TFSReportItemsProvider();
		private readonly ITeamProjectLoader _teamProjectLoader;
		private readonly IMessageBoxProvider _messageBoxProvider = new FlyoutMessageBoxProvider();
		private readonly CancelableProgressOverlayFormManager _overlayFormManager = new CancelableProgressOverlayFormManager();
		private readonly ISettingsHandler _settingsHandler = new SettingsHandler();
		private readonly IConnectionSettingsProvider _connectionSettingsProvider = new TFSConnectionSettingsProvider();
		private readonly IUriFactoryProvider _uriFactoryProvider = new TFSUriFactoryProvider();

		private IList<IReportItem> _testPlanForReport;

		private CancellationTokenSource tokenSource;
		private CancellationToken cancellationToken;

		public ReportGeneratorMainForm()
		{
			InitializeComponent();
			_teamProjectLoader = new TFSTeamProjectLoader(new Progress<string>(SetOverlayLabel));
			InitAppSettings();
			ResetTestConnectionIcon();
		}

		private async void InitAppSettings()
		{
			var settings = _settingsHandler?.Load();
			if (settings == null)
			{
				return;
			}

			InitTemplate(settings);
			await InitTFSConnection(settings);
		}

		private void InitTemplate(IAppSettings settings)
		{
			if (string.IsNullOrEmpty(settings.TemplateFullName) || !File.Exists(settings.TemplateFullName))
			{
				return;
			}
			
			beTemplateFile.EditValue = settings.TemplateFullName;
		}

		private async Task InitTFSConnection(IAppSettings settings)
		{
			if (!string.IsNullOrEmpty(settings.TFSAddress))
			{
				beTFSAddress.EditValue = settings.TFSAddress;
			}

			if (!string.IsNullOrEmpty(settings.ProjectName))
			{
				beProjectName.EditValue = settings.ProjectName;
			}

			await CheckConnection();
		}

		private async void RefreshDataSource_ItemClick(object sender, ItemClickEventArgs e)
		{
			await RefreshDataSource();
		}

		private async Task RefreshDataSource()
		{
			IOverlaySplashScreenHandle overlayHandle = null;

			tokenSource = new CancellationTokenSource();
			cancellationToken = tokenSource.Token;

			SetOverlayLabel("Loading test suite data ...");
			try
			{
				overlayHandle = _overlayFormManager.ShowOverlayForm(this, OnCancelButtonClick);
				var newDataSource = await Task.Run(() =>
				{
					return GetNewDataSource(cancellationToken, new Progress<string>(SetOverlayLabel));
				}, cancellationToken);

				if (newDataSource == null)
				{
					_messageBoxProvider.ShowInformation(this, $"Test plan / test suite with ID {GetTestSuiteID()} was not found", "No data found");
					return;
				}

				_testPlanForReport = newDataSource;
				treeList.DataSource = _testPlanForReport;
				treeList.ExpandToLevel(0);
			}
			catch (OperationCanceledException)
			{
				_overlayFormManager.CloseOverlayForm(overlayHandle);
				_messageBoxProvider.ShowInformation(this, "Operation has been cancelled", "Operation cancelled");
				return;
			}
			catch (Exception ex)
			{
				_overlayFormManager.CloseOverlayForm(overlayHandle);
				_messageBoxProvider.ShowErrorMessage(this, ex.Message, "Error");
				return;
			}
			finally
			{
				_overlayFormManager.CloseOverlayForm(overlayHandle);
        tokenSource?.Dispose();

        this.tokenSource = null;
			}
		}

		private async void GenerateReport_ItemClick(object sender, ItemClickEventArgs e)
		{
			FileInfo document = null;
			IOverlaySplashScreenHandle overlayHandle = null;

			tokenSource = new CancellationTokenSource();
			cancellationToken = tokenSource.Token;

			try
			{
				var template = GetTemplateFileInfo();
				//if(template == null)
				//{
				//	_messageBoxProvider.ShowInformation(this, "Template was not defined by user. Default template will be used.", "Custom template not defined");
				//}
				overlayHandle = _overlayFormManager.ShowOverlayForm(this, OnCancelButtonClick);
				SetOverlayLabel("Loading data ...");
				var builder = await Task.Run(() => _docXBuilderFactory.GetDocXBuilder(DocXBuilderType.DocX), cancellationToken);

				SetOverlayLabel("Generating report ...");
				var progress = new Progress<string>(SetOverlayLabel);
				document = await Task.Run(() => builder.CreateDocument(template, GetDataSourceForReport(cancellationToken, progress), cancellationToken, progress), cancellationToken);
			}
			catch (OperationCanceledException)
			{
				_overlayFormManager.CloseOverlayForm(overlayHandle);
				_messageBoxProvider.ShowInformation(this, "Operation has been cancelled", "Operation cancelled");
				return;
			}
			catch (Exception ex)
			{
				_overlayFormManager.CloseOverlayForm(overlayHandle);
				_messageBoxProvider.ShowErrorMessage(this, ex.Message, "Error");
				return;
			}
			finally
			{
				_overlayFormManager.CloseOverlayForm(overlayHandle);
				if (tokenSource != null)
				{
					tokenSource.Dispose();
				}

				this.tokenSource = null;
			}

			if (!document?.Exists ?? true)
			{
				_messageBoxProvider.ShowErrorMessage(this, "Document was not correctly created", "Error");
				return;
			}

			var openFileResult = _messageBoxProvider.ShowQuestion(this, "Do you want to open document?", "Open document");
			if (openFileResult == DialogResult.Yes)
			{
				Process.Start(document.FullName);
			}
			else if(openFileResult == DialogResult.No)
			{
				_messageBoxProvider.ShowInformation(this, $"File is saved on location: {document.FullName}", "File location");
			}
		}

		private FileInfo GetTemplateFileInfo()
		{
			if(!(beTemplateFile.EditValue is string templateFullName))
			{
				return null;
			}

			if (!File.Exists(templateFullName))
			{
				return null;
			}

			return new FileInfo(templateFullName);
		}

		private void OnCancelButtonClick()
		{
			tokenSource?.Cancel();
		}

		private void SetOverlayLabel(string text)
		{
			_overlayFormManager.UpdateProgressText(text);
		}

		private uint GetTestSuiteID()
		{
			return ConvertToUint(beTestSuiteId.EditValue);
		}

		private uint ConvertToUint(object source)
		{
			try
			{
				return Convert.ToUInt32(source);
			}
			catch
			{
				return 0;
			}
		}

		private IList<IReportItem> GetNewDataSource(CancellationToken cancellationToken, IProgress<string> progress)
		{
			var testSuiteID = GetTestSuiteID();
			if (testSuiteID == 0)
			{
				return null;
			}

			return _testPlanProvider.GetData(GetTeamProject(), _uriFactoryProvider.GetFactory(GetConnectionSettings()), testSuiteID, cancellationToken, progress);
		}

		private IList<IReportItem> GetDataSourceForReport(CancellationToken cancellationToken, IProgress<string> progress)
		{
			return _testPlanForReport ?? GetNewDataSource(cancellationToken, progress);
		}

		private void RepItemTestSuiteID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
		{
			bbiRefresh.Enabled = bbiGenerateReport.Enabled = (string)e.NewValue != string.Empty;
		}

		private void TemplatesFolderRepositoryItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			if (e.Button.Index == 0)
			{
				using (var xtraOpenFileDialog = new XtraOpenFileDialog())
				{
					xtraOpenFileDialog.Filter = "Template|*.docx";
					var result = xtraOpenFileDialog.ShowDialog();
					if (result == DialogResult.OK)
					{
						var selectedFolder = xtraOpenFileDialog.FileName;
						beTemplateFile.EditValue = selectedFolder;
					}
				}
			}
			else if(e.Button.Index == 1)
			{
				beTemplateFile.EditValue = null;
			}
		}

		private void TreeList_KeyDown(object sender, KeyEventArgs e)
		{
			if(treeList.FocusedNode == null)
			{
				return;
			}

			if (e.KeyCode == Keys.Right)
			{
				if (treeList.FocusedNode.Expanded)
				{
					treeList.MoveNext();
				}
				else
				{
					treeList.FocusedNode.Expanded = true;
				}
			}
			if (e.KeyCode == Keys.Left)
			{
				if (treeList.FocusedNode.Expanded)
				{
					treeList.FocusedNode.Expanded = false;
				}
				else
				{
					treeList.MovePrev();
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

			}
			base.Dispose(disposing);
		}

		private void ReportGeneratorMainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			var tempSettings = new TemplateSettings
			{
				TemplateFullName = beTemplateFile.EditValue as string,
				ProjectName = beProjectName.EditValue as string,
				TFSAddress = beTFSAddress.EditValue as string
			};

			try
			{
				_settingsHandler?.Save(tempSettings);
			}
			catch
			{
			}
		}

		private void TreeList_GetStateImage(object sender, GetStateImageEventArgs e)
		{
			var currentDataRecord = treeList.GetDataRecordByNode(e.Node);
			if (!(currentDataRecord is IReportItem currentReportItem))
			{
				return;
			}

			if (currentDataRecord is TestPlan)
			{
				e.NodeImageIndex = 0;
			}
			else if (currentDataRecord is TestSuite)
			{
				e.NodeImageIndex = 1;
			}
			else if (currentDataRecord is TestCase)
			{
				e.NodeImageIndex = 2;
			}
		}

		private void TreeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
		{
			if (e.Node.HasChildren)
			{
				e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
			}
		}

		private void TreeList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			//if (e.Menu is TreeListNodeMenu)
			//{
			//	treeList.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
			//	e.Menu.Items.Add(new DXMenuItem("Expand all", (sndr, args) => treeList.ExpandAll(), treeListPopUpMenuImageCollection.Images[0]));
			//	e.Menu.Items.Add(new DXMenuItem("Collapse all", (sndr, args) => treeList.CollapseAll(), treeListPopUpMenuImageCollection.Images[1]));
			//	//open
			//	//print
			//}
		}

		private void RepItemTFSAddress_EditValueChanged(object sender, EventArgs e)
		{
			ResetTestConnectionIcon();
		}

		private void RepItemProjectName_EditValueChanged(object sender, EventArgs e)
		{
			ResetTestConnectionIcon();
		}

		private void SetAddressEnabled(bool enabled)
		{
			beTFSAddress.Enabled = enabled;
			beProjectName.Enabled = enabled;
		}

		private void ResetTestConnectionIcon()
		{
			testConnectionBarItem.EditValue = testConnectionImageCollection.Images[0];//Properties.Resources.Loading_InitFrame;
		}

		private async Task CheckConnection()
		{
			SetAddressEnabled(false);
			testConnectionBarItem.EditValue = Properties.Resources.Loading;
			try
			{
				bool connected = await TryConnect();
				if (connected)
				{
					testConnectionBarItem.EditValue = testConnectionImageCollection.Images[1];
				}
				else
				{
					testConnectionBarItem.EditValue = testConnectionImageCollection.Images[2];
				}
			}
			finally
			{
				SetAddressEnabled(true);
			}
		}

		private async Task<bool> TryConnect()
		{
			try
			{
				return await Task.Run(() => 
				{
					return GetTeamProject() != null;
				});
			}
			catch (Exception)
			{
				ResetTestConnectionIcon();
				return false;
			}
		}

		private ITestManagementTeamProject GetTeamProject()
		{
			return _teamProjectLoader.Load(GetConnectionSettings());
		}

		private IConnectionSettings GetConnectionSettings()
		{
			return _connectionSettingsProvider.Get(beTFSAddress.EditValue?.ToString(), beProjectName.EditValue?.ToString());
		}

		private async void TestConnectionRepItem_Click(object sender, EventArgs e)
		{
			await CheckConnection();
		}

		private async void BtnSelectConnection_ItemClick(object sender, ItemClickEventArgs e)
		{
			using(var projectPicker = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false))
			{
				var dialogResult = projectPicker.ShowDialog();
				if(dialogResult == DialogResult.Cancel)
				{
					return;
				}

				var uri = projectPicker.SelectedTeamProjectCollection.Uri;
				var project = projectPicker.SelectedProjects[0]?.Name;

				beTFSAddress.EditValue = uri;
				beProjectName.EditValue = project;
				await CheckConnection();
			}
		}
	}
}