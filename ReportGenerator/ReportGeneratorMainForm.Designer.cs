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
			DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
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
			this.beTemplates = new DevExpress.XtraBars.BarEditItem();
			this.templatesLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.templateInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.beTemplatesFolder = new DevExpress.XtraBars.BarEditItem();
			this.templatesFolderRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.pageGroupTCLoad = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.pageGroupExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonTemplate = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.templatesRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.cbTemplates = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.testResultForReportBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemTestSuiteID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templatesLookUpEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templateInfoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templatesFolderRepositoryItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbTemplates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
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
			this.testResultForReportBindingSource.DataSource = typeof(ReportGenerator.TestResultForReport);
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
			gridFormatRule1.Column = this.colOutcome;
			gridFormatRule1.Name = "OutcomePassed";
			formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
			formatConditionRuleExpression1.Expression = "[Outcome] = 2";
			formatConditionRuleExpression1.PredefinedName = "Bold Text";
			gridFormatRule1.Rule = formatConditionRuleExpression1;
			gridFormatRule2.Column = this.colOutcome;
			gridFormatRule2.Name = "OutcomeFailed";
			formatConditionRuleExpression2.Expression = "[Outcome] = 3";
			formatConditionRuleExpression2.PredefinedName = "Red Bold Text";
			gridFormatRule2.Rule = formatConditionRuleExpression2;
			this.gridView.FormatRules.Add(gridFormatRule1);
			this.gridView.FormatRules.Add(gridFormatRule2);
			this.gridView.GridControl = this.gridControl;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.Editable = false;
			this.gridView.OptionsBehavior.ReadOnly = true;
			this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GridView_RowCellStyle);
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
            this.barSuiteName,
            this.beTemplates,
            this.beTemplatesFolder});
			this.ribbonControl.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl.MaxItemId = 32;
			this.ribbonControl.Name = "ribbonControl";
			this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonTemplate});
			this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemTestSuiteID,
            this.repositoryItemButtonEdit1,
            this.cbTemplates,
            this.templatesFolderRepositoryItem,
            this.templatesLookUpEdit,
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemCheckEdit1});
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
			this.bbiGenerateReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.GenerateReport_ItemClick);
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
			this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RefreshDataSource_ItemClick);
			// 
			// beTestSuiteId
			// 
			this.beTestSuiteId.Caption = "Test suite ID:";
			this.beTestSuiteId.Edit = this.repItemTestSuiteID;
			this.beTestSuiteId.EditWidth = 80;
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
			this.repItemTestSuiteID.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.RepItemTestSuiteID_EditValueChanging);
			// 
			// barSuiteName
			// 
			this.barSuiteName.Id = 21;
			this.barSuiteName.Name = "barSuiteName";
			// 
			// beTemplates
			// 
			this.beTemplates.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
			this.beTemplates.Caption = "Template:";
			this.beTemplates.Edit = this.templatesLookUpEdit;
			this.beTemplates.EditWidth = 200;
			this.beTemplates.Id = 23;
			this.beTemplates.Name = "beTemplates";
			toolTipItem1.Text = "Template which will be used for generating final document. If none is selected, d" +
    "efault template will be used.";
			superToolTip1.Items.Add(toolTipItem1);
			this.beTemplates.SuperTip = superToolTip1;
			this.beTemplates.EditValueChanged += new System.EventHandler(this.BeTemplates_EditValueChanged);
			// 
			// templatesLookUpEdit
			// 
			this.templatesLookUpEdit.AutoHeight = false;
			this.templatesLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)});
			this.templatesLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Full Name", 56, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
			this.templatesLookUpEdit.DataSource = this.templateInfoBindingSource;
			this.templatesLookUpEdit.DisplayMember = "Name";
			this.templatesLookUpEdit.Name = "templatesLookUpEdit";
			this.templatesLookUpEdit.NullText = "";
			this.templatesLookUpEdit.ValueMember = "FullName";
			this.templatesLookUpEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.templatesLookUpEdit_ButtonClick);
			// 
			// templateInfoBindingSource
			// 
			this.templateInfoBindingSource.DataSource = typeof(ReportGenerator.TemplateInfo);
			// 
			// beTemplatesFolder
			// 
			this.beTemplatesFolder.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
			this.beTemplatesFolder.Caption = "Folder:     ";
			this.beTemplatesFolder.Edit = this.templatesFolderRepositoryItem;
			this.beTemplatesFolder.EditWidth = 300;
			this.beTemplatesFolder.Id = 24;
			this.beTemplatesFolder.Name = "beTemplatesFolder";
			toolTipItem2.Text = "Folder which contains *.docx templates to choose from";
			superToolTip2.Items.Add(toolTipItem2);
			this.beTemplatesFolder.SuperTip = superToolTip2;
			// 
			// templatesFolderRepositoryItem
			// 
			this.templatesFolderRepositoryItem.AutoHeight = false;
			this.templatesFolderRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.templatesFolderRepositoryItem.Name = "templatesFolderRepositoryItem";
			this.templatesFolderRepositoryItem.ReadOnly = true;
			this.templatesFolderRepositoryItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.templatesFolderRepositoryItem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.TemplatesFolderRepositoryItem_ButtonClick);
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
			// ribbonTemplate
			// 
			this.ribbonTemplate.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.templatesRibbonPageGroup});
			this.ribbonTemplate.Name = "ribbonTemplate";
			this.ribbonTemplate.Text = "Templates";
			// 
			// templatesRibbonPageGroup
			// 
			this.templatesRibbonPageGroup.ItemLinks.Add(this.beTemplatesFolder);
			this.templatesRibbonPageGroup.ItemLinks.Add(this.beTemplates);
			this.templatesRibbonPageGroup.Name = "templatesRibbonPageGroup";
			this.templatesRibbonPageGroup.Text = "Custom template";
			// 
			// repositoryItemButtonEdit1
			// 
			this.repositoryItemButtonEdit1.AutoHeight = false;
			this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
			// 
			// cbTemplates
			// 
			this.cbTemplates.AutoHeight = false;
			this.cbTemplates.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbTemplates.Name = "cbTemplates";
			this.cbTemplates.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// repositoryItemComboBox1
			// 
			this.repositoryItemComboBox1.AutoHeight = false;
			this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
			// 
			// repositoryItemComboBox2
			// 
			this.repositoryItemComboBox2.AutoHeight = false;
			this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
			((System.ComponentModel.ISupportInitialize)(this.templatesLookUpEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.templateInfoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.templatesFolderRepositoryItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbTemplates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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
        private DevExpress.XtraBars.BarEditItem beTestSuiteId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repItemTestSuiteID;
        private DevExpress.XtraBars.BarStaticItem barSuiteName;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonTemplate;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup templatesRibbonPageGroup;
		private DevExpress.XtraBars.BarEditItem beTemplates;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbTemplates;
		private DevExpress.XtraBars.BarEditItem beTemplatesFolder;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit templatesFolderRepositoryItem;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit templatesLookUpEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
		private System.Windows.Forms.BindingSource templateInfoBindingSource;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
	}
}