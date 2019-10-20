using System;
using DevExpress.XtraBars;
using ReportGenerator;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.Utils.CommonDialogs;
using ReportGenerator.DataProviders.TFSTestSuiteDataProvider;

namespace ReportGenerator
{
	public partial class ReportGeneratorMainForm : RibbonForm
	{
		private readonly IDocXBuilderFactory _docXBuilderFactory = new DocXBuilderFactory();
		private readonly ITestSuiteForReportProvider _testSuiteForReportProvider = new DummyTestSuiteForReportProvider();
		//private readonly ITestSuiteForReportProvider _testSuiteForReportProvider = new TFSPlanTestSuiteProvider();
		private readonly IMessageBoxProvider _messageBoxProvider = new FlyoutMessageBoxProvider();
		private readonly CancelableProgressOverlayFormManager _overlayFormManager = new CancelableProgressOverlayFormManager();

		private TestSuiteForReport _testSuiteForReport;

		private CancellationTokenSource tokenSource;
		private CancellationToken cancellationToken;

		public ReportGeneratorMainForm()
		{
			InitializeComponent();
			InitAppSettings();
		}

		private void InitAppSettings()
		{
			InitTemplates();
		}

		private void InitTemplates()
		{
			var templatesPath = Properties.Settings.Default.TemplatesPath;
			if (string.IsNullOrEmpty(templatesPath) || !Directory.Exists(templatesPath))
			{
				return;
			}

			beTemplatesFolder.EditValue = templatesPath;

			UpdateAvailableTemplates(templatesPath);

			var lastUsedTemplateName = Properties.Settings.Default.SelectedTemplate;
			var dsTemplateInfo = GetDataSourceTemplateByName(lastUsedTemplateName);
			if (string.IsNullOrEmpty(lastUsedTemplateName) || dsTemplateInfo == null)
			{
				return;
			}

			beTemplates.EditValue = dsTemplateInfo.FullName;
		}

		private async void RefreshDataSource_ItemClick(object sender, ItemClickEventArgs e)
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
				});

				if (newDataSource == null)
				{
					return;
				}

				_testSuiteForReport = newDataSource;
				var testResultsDataSource = _testSuiteForReport.TestResults;
				gridControl.DataSource = testResultsDataSource;
				bsiRecordsCount.Caption = "Test cases : " + (testResultsDataSource?.Count ?? 0);
				barSuiteName.Caption = _testSuiteForReport.TestSuiteCaption;
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
				_messageBoxProvider.ShowErrorMessage(this, ex.Message, ex.GetType().ToString());
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
				if(template == null)
				{
					_messageBoxProvider.ShowInformation(this, "Template was not defined by user. Default template will be used.", "Custom template not defined");
				}
				overlayHandle = _overlayFormManager.ShowOverlayForm(this, OnCancelButtonClick);
				SetOverlayLabel("Loading data ...");
				var builder = await Task.Run(() => _docXBuilderFactory.GetDocXBuilder(DocXBuilderType.FreeSpire, GetDataSourceForReport(cancellationToken, new Progress<string>(SetOverlayLabel))));

				SetOverlayLabel("Generating report ...");
				document = await Task.Run(() => builder.CreateDocument(template, cancellationToken, new Progress<string>(SetOverlayLabel)));
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
				_messageBoxProvider.ShowErrorMessage(this, ex.Message, ex.GetType().ToString());
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
			if(!(beTemplates.EditValue is string templateFullName))
			{
				return null;
			}

			if (!File.Exists(templateFullName))
			{
				return null;
			}

			return new FileInfo(templateFullName);
		}

		private void GridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
		{
			GridView view = sender as GridView;
			if (view.FocusedRowHandle == e.RowHandle)
			{
				e.Appearance.BackColor = view.PaintAppearance.FocusedRow.BackColor;
			}
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

		private TestSuiteForReport GetNewDataSource(CancellationToken cancellationToken, IProgress<string> progress)
		{
			var testSuiteID = GetTestSuiteID();
			if (testSuiteID == 0)
			{
				return null;
			}

			return _testSuiteForReportProvider.GetData(testSuiteID, cancellationToken, progress);
		}

		private TestSuiteForReport GetDataSourceForReport(CancellationToken cancellationToken, IProgress<string> progress)
		{
			return _testSuiteForReport ?? GetNewDataSource(cancellationToken, progress);
		}

		private void RepItemTestSuiteID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
		{
			bbiRefresh.Enabled = bbiGenerateReport.Enabled = ConvertToUint(e.NewValue) != 0;
		}

		private void UpdateAvailableTemplates(string templatesFolderPath)
		{
			var templates = GetTemplatesFromPath(templatesFolderPath);
			templatesLookUpEdit.DataSource = templates;
		}

		private IEnumerable<TemplateInfo> GetTemplatesFromPath(string templatesFolderPath)
		{
			if (string.IsNullOrEmpty(templatesFolderPath) || !Directory.Exists(templatesFolderPath))
			{
				return Enumerable.Empty<TemplateInfo>();
			}

			return Directory.GetFiles(templatesFolderPath, "*.docx")
				.Select(fullName =>
				{
					var fi = new FileInfo(fullName);
					return new TemplateInfo(fi.Name, fi.FullName);
				})
				.OrderBy(ti => ti.Name);
		}

		private void TemplatesFolderRepositoryItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			using (var xtraFolderBrowserDialog = new XtraFolderBrowserDialog())
			{
				xtraFolderBrowserDialog.DialogStyle = FolderBrowserDialogStyle.Wide;
				var result = xtraFolderBrowserDialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					var selectedFolder = xtraFolderBrowserDialog.SelectedPath;
					beTemplatesFolder.EditValue = selectedFolder;

					UpdateAvailableTemplates(selectedFolder);
					beTemplates.EditValue = string.Empty;

					Properties.Settings.Default.TemplatesPath = selectedFolder;
					Properties.Settings.Default.Save();
				}
			}
		}

		private void BeTemplates_EditValueChanged(object sender, EventArgs e)
		{
			SaveSelectedTemplate();
		}

		private void SaveSelectedTemplate()
		{
			if (!(beTemplates.EditValue is string fullTemplatePath))
			{
				return;
			}

			Properties.Settings.Default.SelectedTemplate = fullTemplatePath;
			Properties.Settings.Default.Save();
		}

		private TemplateInfo GetDataSourceTemplateByName(string templateName)
		{
			if (!(templatesLookUpEdit.DataSource is IEnumerable<TemplateInfo> dataSource))
			{
				return null;
			}

			return dataSource.FirstOrDefault(item => item.FullName.Equals(templateName));
		}

		private void templatesLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			if(e.Button.Index == 1)
			{
				beTemplates.EditValue = string.Empty;
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
	}

	public class TemplateInfo
	{
		public string Name { get; }

		public string FullName { get; }

		public TemplateInfo(string name, string fullName)
		{
			Name = name;
			FullName = fullName;
		}
	}
}