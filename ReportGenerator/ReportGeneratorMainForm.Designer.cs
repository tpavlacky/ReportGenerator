namespace ReportGenerator
{
    partial class ReportGeneratorMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			this.colOutcome = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridControl = new DevExpress.XtraGrid.GridControl();
			this.testResultForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSummary = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTestCaseId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTestResultId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTestRunId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTester = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colConfiguration = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRunBy = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDateCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDurationInSeconds = new DevExpress.XtraGrid.Columns.GridColumn();
			this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.bbiGenerateReport = new DevExpress.XtraBars.BarButtonItem();
			this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
			this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
			this.beTestSuiteId = new DevExpress.XtraBars.BarEditItem();
			this.repItemTestSuiteID = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.barSuiteName = new DevExpress.XtraBars.BarStaticItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.pageGroupTCLoad = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.pageGroupExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.testSuiteForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.testResultForReportBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemTestSuiteID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.testSuiteForReportBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// colOutcome
			// 
			this.colOutcome.FieldName = "Outcome";
			this.colOutcome.Name = "colOutcome";
			this.colOutcome.OptionsColumn.ReadOnly = true;
			this.colOutcome.Visible = true;
			this.colOutcome.VisibleIndex = 1;
			this.colOutcome.Width = 69;
			// 
			// gridControl
			// 
			this.gridControl.DataSource = this.testResultForReportBindingSource;
			this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl.Location = new System.Drawing.Point(0, 143);
			this.gridControl.MainView = this.gridView;
			this.gridControl.MenuManager = this.ribbonControl;
			this.gridControl.Name = "gridControl";
			this.gridControl.Size = new System.Drawing.Size(790, 456);
			this.gridControl.TabIndex = 2;
			this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// testResultForReportBindingSource
			// 
			this.testResultForReportBindingSource.DataSource = typeof(ProtocolGenerator.TestResultForReport);
			// 
			// gridView
			// 
			this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colSummary,
            this.colTestCaseId,
            this.colOutcome,
            this.colTestResultId,
            this.colTestRunId,
            this.colTester,
            this.colConfiguration,
            this.colRunBy,
            this.colDateCompleted,
            this.colDurationInSeconds});
			gridFormatRule3.Column = this.colOutcome;
			gridFormatRule3.Name = "OutcomePassed";
			formatConditionRuleExpression3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			formatConditionRuleExpression3.Appearance.Options.UseForeColor = true;
			formatConditionRuleExpression3.Expression = "[Outcome] = 1";
			formatConditionRuleExpression3.PredefinedName = "Bold Text";
			gridFormatRule3.Rule = formatConditionRuleExpression3;
			gridFormatRule4.Column = this.colOutcome;
			gridFormatRule4.Name = "OutcomeFailed";
			formatConditionRuleExpression4.Expression = "[Outcome] = 0";
			formatConditionRuleExpression4.PredefinedName = "Red Bold Text";
			gridFormatRule4.Rule = formatConditionRuleExpression4;
			this.gridView.FormatRules.Add(gridFormatRule3);
			this.gridView.FormatRules.Add(gridFormatRule4);
			this.gridView.GridControl = this.gridControl;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.Editable = false;
			this.gridView.OptionsBehavior.ReadOnly = true;
			this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_RowCellStyle);
			// 
			// colTitle
			// 
			this.colTitle.FieldName = "Title";
			this.colTitle.Name = "colTitle";
			this.colTitle.OptionsColumn.ReadOnly = true;
			this.colTitle.Visible = true;
			this.colTitle.VisibleIndex = 2;
			this.colTitle.Width = 69;
			// 
			// colSummary
			// 
			this.colSummary.FieldName = "Summary";
			this.colSummary.Name = "colSummary";
			this.colSummary.OptionsColumn.ReadOnly = true;
			// 
			// colTestCaseId
			// 
			this.colTestCaseId.FieldName = "TestCaseId";
			this.colTestCaseId.Name = "colTestCaseId";
			this.colTestCaseId.OptionsColumn.ReadOnly = true;
			this.colTestCaseId.Visible = true;
			this.colTestCaseId.VisibleIndex = 0;
			this.colTestCaseId.Width = 69;
			// 
			// colTestResultId
			// 
			this.colTestResultId.FieldName = "TestResultId";
			this.colTestResultId.Name = "colTestResultId";
			this.colTestResultId.OptionsColumn.ReadOnly = true;
			this.colTestResultId.Width = 102;
			// 
			// colTestRunId
			// 
			this.colTestRunId.FieldName = "TestRunId";
			this.colTestRunId.Name = "colTestRunId";
			this.colTestRunId.OptionsColumn.ReadOnly = true;
			this.colTestRunId.Width = 63;
			// 
			// colTester
			// 
			this.colTester.FieldName = "Tester";
			this.colTester.Name = "colTester";
			this.colTester.OptionsColumn.ReadOnly = true;
			this.colTester.Visible = true;
			this.colTester.VisibleIndex = 4;
			this.colTester.Width = 63;
			// 
			// colConfiguration
			// 
			this.colConfiguration.FieldName = "Configuration";
			this.colConfiguration.Name = "colConfiguration";
			this.colConfiguration.OptionsColumn.ReadOnly = true;
			this.colConfiguration.Width = 63;
			// 
			// colRunBy
			// 
			this.colRunBy.FieldName = "RunBy";
			this.colRunBy.Name = "colRunBy";
			this.colRunBy.OptionsColumn.ReadOnly = true;
			this.colRunBy.Visible = true;
			this.colRunBy.VisibleIndex = 3;
			this.colRunBy.Width = 63;
			// 
			// colDateCompleted
			// 
			this.colDateCompleted.FieldName = "DateCompleted";
			this.colDateCompleted.Name = "colDateCompleted";
			this.colDateCompleted.OptionsColumn.ReadOnly = true;
			this.colDateCompleted.Visible = true;
			this.colDateCompleted.VisibleIndex = 5;
			this.colDateCompleted.Width = 63;
			// 
			// colDurationInSeconds
			// 
			this.colDurationInSeconds.FieldName = "DurationInSeconds";
			this.colDurationInSeconds.Name = "colDurationInSeconds";
			this.colDurationInSeconds.OptionsColumn.ReadOnly = true;
			this.colDurationInSeconds.Width = 70;
			// 
			// ribbonControl
			// 
			this.ribbonControl.ExpandCollapseItem.Id = 0;
			this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiGenerateReport,
            this.bsiRecordsCount,
            this.bbiRefresh,
            this.beTestSuiteId,
            this.barSuiteName});
			this.ribbonControl.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl.MaxItemId = 22;
			this.ribbonControl.Name = "ribbonControl";
			this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemTestSuiteID});
			this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
			this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
			this.ribbonControl.Size = new System.Drawing.Size(790, 143);
			this.ribbonControl.StatusBar = this.ribbonStatusBar;
			this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// bbiGenerateReport
			// 
			this.bbiGenerateReport.Caption = "Generate report";
			this.bbiGenerateReport.Enabled = false;
			this.bbiGenerateReport.Id = 14;
			this.bbiGenerateReport.ImageOptions.ImageUri.Uri = "Preview";
			this.bbiGenerateReport.Name = "bbiGenerateReport";
			this.bbiGenerateReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGenerateReport_ItemClick);
			// 
			// bsiRecordsCount
			// 
			this.bsiRecordsCount.Caption = "Test cases : 0";
			this.bsiRecordsCount.Id = 15;
			this.bsiRecordsCount.Name = "bsiRecordsCount";
			// 
			// bbiRefresh
			// 
			this.bbiRefresh.Caption = "Load";
			this.bbiRefresh.Enabled = false;
			this.bbiRefresh.Id = 19;
			this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
			this.bbiRefresh.Name = "bbiRefresh";
			this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
			// 
			// beTestSuiteId
			// 
			this.beTestSuiteId.Caption = "Test suite ID:";
			this.beTestSuiteId.Edit = this.repItemTestSuiteID;
			this.beTestSuiteId.EditWidth = 60;
			this.beTestSuiteId.Id = 20;
			this.beTestSuiteId.Name = "beTestSuiteId";
			// 
			// repItemTestSuiteID
			// 
			this.repItemTestSuiteID.AutoHeight = false;
			this.repItemTestSuiteID.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repItemTestSuiteID.Mask.EditMask = "\\d+";
			this.repItemTestSuiteID.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.repItemTestSuiteID.Name = "repItemTestSuiteID";
			this.repItemTestSuiteID.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repItemTestSuiteID_EditValueChanging);
			// 
			// barSuiteName
			// 
			this.barSuiteName.Id = 21;
			this.barSuiteName.Name = "barSuiteName";
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pageGroupTCLoad,
            this.pageGroupExport});
			this.ribbonPage1.MergeOrder = 0;
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Report";
			// 
			// pageGroupTCLoad
			// 
			this.pageGroupTCLoad.AllowTextClipping = false;
			this.pageGroupTCLoad.ItemLinks.Add(this.beTestSuiteId);
			this.pageGroupTCLoad.ItemLinks.Add(this.bbiRefresh);
			this.pageGroupTCLoad.Name = "pageGroupTCLoad";
			this.pageGroupTCLoad.ShowCaptionButton = false;
			this.pageGroupTCLoad.Text = "General";
			// 
			// pageGroupExport
			// 
			this.pageGroupExport.AllowTextClipping = false;
			this.pageGroupExport.ItemLinks.Add(this.bbiGenerateReport);
			this.pageGroupExport.Name = "pageGroupExport";
			this.pageGroupExport.ShowCaptionButton = false;
			this.pageGroupExport.Text = "Export";
			// 
			// ribbonStatusBar
			// 
			this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
			this.ribbonStatusBar.ItemLinks.Add(this.barSuiteName);
			this.ribbonStatusBar.Location = new System.Drawing.Point(0, 568);
			this.ribbonStatusBar.Name = "ribbonStatusBar";
			this.ribbonStatusBar.Ribbon = this.ribbonControl;
			this.ribbonStatusBar.Size = new System.Drawing.Size(790, 31);
			// 
			// testSuiteForReportBindingSource
			// 
			this.testSuiteForReportBindingSource.DataSource = typeof(ProtocolGenerator.TestSuiteForReport);
			// 
			// ReportGeneratorMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 599);
			this.Controls.Add(this.ribbonStatusBar);
			this.Controls.Add(this.gridControl);
			this.Controls.Add(this.ribbonControl);
			this.Name = "ReportGeneratorMainForm";
			this.Ribbon = this.ribbonControl;
			this.StatusBar = this.ribbonStatusBar;
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.testResultForReportBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemTestSuiteID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.testSuiteForReportBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageGroupTCLoad;
        private DevExpress.XtraBars.BarButtonItem bbiGenerateReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageGroupExport;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource testResultForReportBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colTestCaseId;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcome;
        private DevExpress.XtraGrid.Columns.GridColumn colTestResultId;
        private DevExpress.XtraGrid.Columns.GridColumn colTestRunId;
        private DevExpress.XtraGrid.Columns.GridColumn colTester;
        private DevExpress.XtraGrid.Columns.GridColumn colConfiguration;
        private DevExpress.XtraGrid.Columns.GridColumn colRunBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn colDurationInSeconds;
        private System.Windows.Forms.BindingSource testSuiteForReportBindingSource;
        private DevExpress.XtraBars.BarEditItem beTestSuiteId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repItemTestSuiteID;
        private DevExpress.XtraBars.BarStaticItem barSuiteName;
    }
}