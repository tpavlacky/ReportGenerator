using System;
using DevExpress.XtraBars;
using ProtocolGenerator;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Threading.Tasks;

namespace ReportGenerator
{
	public partial class ReportGeneratorMainForm : RibbonForm
	{
		private readonly IDocXBuilderFactory _docXBuilderFactory = new DocXBuilderFactory();
		private readonly ITestSuiteForReportProvider _testSuiteForReportProvider = new DummyTestSuiteForReportProvider();
		private readonly IMessageBoxProvider _messageBoxProvider = new FlyoutMessageBoxProvider();
		private readonly CancelableProgressOverlayFormManager _overlayFormManager = new CancelableProgressOverlayFormManager();

		private TestSuiteForReport _testSuiteForReport;

		private CancellationTokenSource tokenSource;
		private CancellationToken cancellationToken;

		public ReportGeneratorMainForm()
		{
			InitializeComponent();
		}

		private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
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

		private async void bbiGenerateReport_ItemClick(object sender, ItemClickEventArgs e)
		{
			FileInfo document = null;
			IOverlaySplashScreenHandle overlayHandle = null;

			tokenSource = new CancellationTokenSource();
			cancellationToken = tokenSource.Token;

			try
			{
				overlayHandle = _overlayFormManager.ShowOverlayForm(this, OnCancelButtonClick);
				SetOverlayLabel("Loading data ...");
				var builder = await Task.Run(() => _docXBuilderFactory.GetDocXBuilder(DocXBuilderType.FreeSpire, GetDataSourceForReport(cancellationToken, new Progress<string>(SetOverlayLabel))));

				SetOverlayLabel("Generating report ...");
				document = await Task.Run(() => builder.CreateDocument(cancellationToken, new Progress<string>(SetOverlayLabel)));
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

		private void gridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
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

			return _testSuiteForReportProvider.GetData(cancellationToken, progress);
		}

		private TestSuiteForReport GetDataSourceForReport(CancellationToken cancellationToken, IProgress<string> progress)
		{
			return _testSuiteForReport ?? GetNewDataSource(cancellationToken, progress);
		}

		private void repItemTestSuiteID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
		{
			bbiRefresh.Enabled =
					bbiGenerateReport.Enabled = ConvertToUint(e.NewValue) != 0;
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
}