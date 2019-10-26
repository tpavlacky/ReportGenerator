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
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportGeneratorMainForm));
			DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule1 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule2 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			this.colTestOutcome = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.testResultForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.bbiGenerateReport = new DevExpress.XtraBars.BarButtonItem();
			this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
			this.beTestSuiteId = new DevExpress.XtraBars.BarEditItem();
			this.repItemTestSuiteID = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.beTemplateFile = new DevExpress.XtraBars.BarEditItem();
			this.templateFileRepItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.beTFSAddress = new DevExpress.XtraBars.BarEditItem();
			this.repItemTFSAddress = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.beProjectName = new DevExpress.XtraBars.BarEditItem();
			this.repItemProjectName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
			this.testConnectionBarItem = new DevExpress.XtraBars.BarEditItem();
			this.testConnectionRepItem = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.pageGroupTCLoad = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.pageGroupExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonTemplate = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.templatesRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.cbTemplates = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
			this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.templateInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.IReportItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.treeListNodeTypesImageCollection = new DevExpress.Utils.ImageCollection(this.components);
			this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
			this.colParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colTestedBy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colTestedDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.treeList = new DevExpress.XtraTreeList.TreeList();
			this.colURL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.repItemColIDHyperlinkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
			this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
			this.treeListPopUpMenuImageCollection = new DevExpress.Utils.ImageCollection(this.components);
			this.testConnectionImageCollection = new DevExpress.Utils.ImageCollection(this.components);
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.btnSelectConnection = new DevExpress.XtraBars.BarButtonItem();
			((System.ComponentModel.ISupportInitialize)(this.testResultForReportBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemTestSuiteID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templateFileRepItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemTFSAddress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemProjectName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.testConnectionRepItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbTemplates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templateInfoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IReportItemBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeListNodeTypesImageCollection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemColIDHyperlinkEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeListPopUpMenuImageCollection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.testConnectionImageCollection)).BeginInit();
			this.SuspendLayout();
			// 
			// colTestOutcome
			// 
			this.colTestOutcome.AppearanceCell.Options.UseTextOptions = true;
			this.colTestOutcome.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.colTestOutcome.FieldName = "TestOutcome";
			this.colTestOutcome.Name = "colTestOutcome";
			this.colTestOutcome.OptionsColumn.AllowEdit = false;
			this.colTestOutcome.OptionsColumn.AllowFocus = false;
			this.colTestOutcome.OptionsColumn.ReadOnly = true;
			this.colTestOutcome.Visible = true;
			this.colTestOutcome.VisibleIndex = 2;
			this.colTestOutcome.Width = 103;
			// 
			// testResultForReportBindingSource
			// 
			this.testResultForReportBindingSource.DataSource = typeof(ReportGenerator.TestResultForReport);
			// 
			// ribbonControl
			// 
			this.ribbonControl.ExpandCollapseItem.Id = 0;
			this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiGenerateReport,
            this.bbiRefresh,
            this.beTestSuiteId,
            this.beTemplateFile,
            this.barButtonItem1,
            this.barButtonItem2,
            this.beTFSAddress,
            this.beProjectName,
            this.barButtonItem3,
            this.testConnectionBarItem,
            this.btnSelectConnection});
			this.ribbonControl.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl.MaxItemId = 59;
			this.ribbonControl.Name = "ribbonControl";
			this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonTemplate,
            this.ribbonPage2});
			this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemTestSuiteID,
            this.repositoryItemButtonEdit1,
            this.cbTemplates,
            this.templateFileRepItem,
            this.repItemTFSAddress,
            this.repositoryItemHyperLinkEdit1,
            this.repItemProjectName,
            this.testConnectionRepItem,
            this.repositoryItemPictureEdit2});
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
			this.beTestSuiteId.Caption = "Test plan/suite ID:";
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
			// beTemplateFile
			// 
			this.beTemplateFile.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
			this.beTemplateFile.Caption = "Template: ";
			this.beTemplateFile.Edit = this.templateFileRepItem;
			this.beTemplateFile.EditWidth = 300;
			this.beTemplateFile.Id = 24;
			this.beTemplateFile.Name = "beTemplateFile";
			toolTipItem1.Text = "File which will be used as template for creation of final report. If left empty, " +
    "default template will be used.";
			superToolTip1.Items.Add(toolTipItem1);
			this.beTemplateFile.SuperTip = superToolTip1;
			// 
			// templateFileRepItem
			// 
			this.templateFileRepItem.AutoHeight = false;
			this.templateFileRepItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.templateFileRepItem.Name = "templateFileRepItem";
			this.templateFileRepItem.ReadOnly = true;
			this.templateFileRepItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.templateFileRepItem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.TemplatesFolderRepositoryItem_ButtonClick);
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "Expand all";
			this.barButtonItem1.Id = 32;
			this.barButtonItem1.Name = "barButtonItem1";
			// 
			// barButtonItem2
			// 
			this.barButtonItem2.Caption = "Collapse all";
			this.barButtonItem2.Id = 33;
			this.barButtonItem2.Name = "barButtonItem2";
			// 
			// beTFSAddressBase
			// 
			this.beTFSAddress.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
			this.beTFSAddress.Caption = "TFS address:  ";
			this.beTFSAddress.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.beTFSAddress.Edit = this.repItemTFSAddress;
			this.beTFSAddress.EditValue = "https://tfs.dev.its:8090/tfs/Office%204.6/";
			this.beTFSAddress.EditWidth = 250;
			this.beTFSAddress.Id = 34;
			this.beTFSAddress.Name = "beTFSAddressBase";
			// 
			// repItemTFSAddress
			// 
			this.repItemTFSAddress.AutoHeight = false;
			this.repItemTFSAddress.Name = "repItemTFSAddress";
			this.repItemTFSAddress.EditValueChanged += new System.EventHandler(this.RepItemTFSAddress_EditValueChanged);
			// 
			// beProjectName
			// 
			this.beProjectName.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.False;
			this.beProjectName.Caption = "Project name: ";
			this.beProjectName.Edit = this.repItemProjectName;
			this.beProjectName.EditValue = "TP DCMS2";
			this.beProjectName.EditWidth = 150;
			this.beProjectName.Id = 35;
			this.beProjectName.Name = "beProjectName";
			// 
			// repItemProjectName
			// 
			this.repItemProjectName.AutoHeight = false;
			this.repItemProjectName.Name = "repItemProjectName";
			this.repItemProjectName.EditValueChanged += new System.EventHandler(this.RepItemProjectName_EditValueChanged);
			// 
			// barButtonItem3
			// 
			this.barButtonItem3.Caption = "barButtonItem3";
			this.barButtonItem3.Id = 44;
			this.barButtonItem3.Name = "barButtonItem3";
			// 
			// testConnectionBarItem
			// 
			this.testConnectionBarItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
			this.testConnectionBarItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.testConnectionBarItem.Edit = this.testConnectionRepItem;
			this.testConnectionBarItem.EditHeight = 32;
			this.testConnectionBarItem.EditWidth = 32;
			this.testConnectionBarItem.Id = 52;
			this.testConnectionBarItem.Name = "testConnectionBarItem";
			this.testConnectionBarItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			toolTipItem2.Text = "Test connection\r\n";
			superToolTip2.Items.Add(toolTipItem2);
			this.testConnectionBarItem.SuperTip = superToolTip2;
			// 
			// testConnectionRepItem
			// 
			this.testConnectionRepItem.Appearance.BackColor = System.Drawing.Color.White;
			this.testConnectionRepItem.Appearance.Options.UseBackColor = true;
			this.testConnectionRepItem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.testConnectionRepItem.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("testConnectionRepItem.InitialImageOptions.Image")));
			this.testConnectionRepItem.Name = "testConnectionRepItem";
			this.testConnectionRepItem.ShowMenu = false;
			this.testConnectionRepItem.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
			this.testConnectionRepItem.Click += new System.EventHandler(this.TestConnectionRepItem_Click);
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
			this.pageGroupTCLoad.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
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
			this.ribbonTemplate.Text = "Template";
			// 
			// templatesRibbonPageGroup
			// 
			this.templatesRibbonPageGroup.ItemLinks.Add(this.beTemplateFile);
			this.templatesRibbonPageGroup.Name = "templatesRibbonPageGroup";
			this.templatesRibbonPageGroup.Text = "Custom template";
			// 
			// ribbonPage2
			// 
			this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
			this.ribbonPage2.Name = "ribbonPage2";
			this.ribbonPage2.Text = "Settings";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.AllowTextClipping = false;
			this.ribbonPageGroup1.ItemLinks.Add(this.beTFSAddress, true);
			this.ribbonPageGroup1.ItemLinks.Add(this.beProjectName);
			this.ribbonPageGroup1.ItemLinks.Add(this.testConnectionBarItem);
			this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.TwoRows;
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
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
			// repositoryItemHyperLinkEdit1
			// 
			this.repositoryItemHyperLinkEdit1.AutoHeight = false;
			this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
			this.repositoryItemHyperLinkEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
			// 
			// repositoryItemPictureEdit2
			// 
			this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
			// 
			// ribbonStatusBar
			// 
			this.ribbonStatusBar.Location = new System.Drawing.Point(0, 568);
			this.ribbonStatusBar.Name = "ribbonStatusBar";
			this.ribbonStatusBar.Ribbon = this.ribbonControl;
			this.ribbonStatusBar.Size = new System.Drawing.Size(790, 31);
			// 
			// templateInfoBindingSource
			// 
			this.templateInfoBindingSource.DataSource = typeof(ReportGenerator.TemplateInfo);
			// 
			// IReportItemBindingSource
			// 
			this.IReportItemBindingSource.DataSource = typeof(ReportGenerator.Model.IReportItem);
			// 
			// treeListNodeTypesImageCollection
			// 
			this.treeListNodeTypesImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("treeListNodeTypesImageCollection.ImageStream")));
			this.treeListNodeTypesImageCollection.Images.SetKeyName(0, "switchtimescalesto_16x16.png");
			this.treeListNodeTypesImageCollection.Images.SetKeyName(1, "kisspng-computer-icons-checklist-iconfinder-check-checklist-document-form-list-re" +
        "port-te-5ab0470a055be8.366942111521501962022.png");
			this.treeListNodeTypesImageCollection.Images.SetKeyName(2, "forcetesting_16x16.png");
			this.treeListNodeTypesImageCollection.Images.SetKeyName(3, "forcetesting_16x16.png");
			this.treeListNodeTypesImageCollection.Images.SetKeyName(4, "TestSuiteIcon.png");
			this.treeListNodeTypesImageCollection.Images.SetKeyName(5, "i383-512.png");
			this.treeListNodeTypesImageCollection.Images.SetKeyName(6, "TestPlanIcon.png");
			// 
			// colID
			// 
			this.colID.AppearanceCell.Options.UseTextOptions = true;
			this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.colID.FieldName = "ID";
			this.colID.Name = "colID";
			this.colID.OptionsColumn.AllowEdit = false;
			this.colID.OptionsColumn.AllowFocus = false;
			this.colID.OptionsColumn.ReadOnly = true;
			this.colID.Visible = true;
			this.colID.VisibleIndex = 1;
			this.colID.Width = 71;
			// 
			// repositoryItemHypertextLabel1
			// 
			this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
			// 
			// colParentID
			// 
			this.colParentID.FieldName = "ParentID";
			this.colParentID.Name = "colParentID";
			this.colParentID.OptionsColumn.AllowEdit = false;
			this.colParentID.OptionsColumn.AllowFocus = false;
			this.colParentID.OptionsColumn.ReadOnly = true;
			// 
			// colCaption
			// 
			this.colCaption.AppearanceCell.Options.UseTextOptions = true;
			this.colCaption.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.colCaption.FieldName = "Caption";
			this.colCaption.Name = "colCaption";
			this.colCaption.OptionsColumn.AllowEdit = false;
			this.colCaption.OptionsColumn.AllowFocus = false;
			this.colCaption.OptionsColumn.ReadOnly = true;
			this.colCaption.Visible = true;
			this.colCaption.VisibleIndex = 0;
			this.colCaption.Width = 261;
			// 
			// colTestedBy
			// 
			this.colTestedBy.AppearanceCell.Options.UseTextOptions = true;
			this.colTestedBy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.colTestedBy.FieldName = "TestedBy";
			this.colTestedBy.Name = "colTestedBy";
			this.colTestedBy.OptionsColumn.AllowEdit = false;
			this.colTestedBy.OptionsColumn.AllowFocus = false;
			this.colTestedBy.OptionsColumn.ReadOnly = true;
			this.colTestedBy.Visible = true;
			this.colTestedBy.VisibleIndex = 3;
			this.colTestedBy.Width = 112;
			// 
			// colTestedDate
			// 
			this.colTestedDate.AppearanceCell.Options.UseTextOptions = true;
			this.colTestedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.colTestedDate.FieldName = "TestedDate";
			this.colTestedDate.Name = "colTestedDate";
			this.colTestedDate.OptionsColumn.AllowEdit = false;
			this.colTestedDate.OptionsColumn.AllowFocus = false;
			this.colTestedDate.OptionsColumn.ReadOnly = true;
			this.colTestedDate.Visible = true;
			this.colTestedDate.VisibleIndex = 4;
			this.colTestedDate.Width = 183;
			// 
			// treeList
			// 
			this.treeList.ChildListFieldName = "Children";
			this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colParentID,
            this.colCaption,
            this.colTestOutcome,
            this.colTestedBy,
            this.colTestedDate,
            this.colURL});
			this.treeList.CustomizationFormBounds = new System.Drawing.Rectangle(857, 478, 266, 252);
			this.treeList.DataSource = this.IReportItemBindingSource;
			this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
			treeListFormatRule1.ApplyToRow = true;
			treeListFormatRule1.Column = this.colTestOutcome;
			treeListFormatRule1.Name = "PassedOutcome";
			formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
			formatConditionRuleExpression1.Expression = "[TestOutcome] = 2";
			treeListFormatRule1.Rule = formatConditionRuleExpression1;
			treeListFormatRule2.ApplyToRow = true;
			treeListFormatRule2.Column = this.colTestOutcome;
			treeListFormatRule2.Name = "FailedOutcome";
			formatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.Red;
			formatConditionRuleExpression2.Appearance.Options.UseForeColor = true;
			formatConditionRuleExpression2.Expression = "[TestOutcome] = 3";
			treeListFormatRule2.Rule = formatConditionRuleExpression2;
			this.treeList.FormatRules.Add(treeListFormatRule1);
			this.treeList.FormatRules.Add(treeListFormatRule2);
			this.treeList.ImageIndexFieldName = "";
			this.treeList.Location = new System.Drawing.Point(0, 143);
			this.treeList.Name = "treeList";
			this.treeList.OptionsBehavior.PopulateServiceColumns = true;
			this.treeList.OptionsView.RowImagesShowMode = DevExpress.XtraTreeList.RowImagesShowMode.InIndent;
			this.treeList.OptionsView.ShowHorzLines = false;
			this.treeList.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.False;
			this.treeList.OptionsView.ShowVertLines = false;
			this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemHypertextLabel1,
            this.repItemColIDHyperlinkEdit});
			this.treeList.Size = new System.Drawing.Size(790, 425);
			this.treeList.StateImageList = this.treeListNodeTypesImageCollection;
			this.treeList.TabIndex = 5;
			this.treeList.TreeLevelWidth = 12;
			this.treeList.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.TreeList_GetStateImage);
			this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.TreeList_NodeCellStyle);
			this.treeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.TreeList_PopupMenuShowing);
			this.treeList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeList_KeyDown);
			// 
			// colURL
			// 
			this.colURL.Caption = "Open";
			this.colURL.ColumnEdit = this.repItemColIDHyperlinkEdit;
			this.colURL.FieldName = "URL";
			this.colURL.Name = "colURL";
			this.colURL.OptionsColumn.ReadOnly = true;
			this.colURL.Visible = true;
			this.colURL.VisibleIndex = 5;
			this.colURL.Width = 42;
			// 
			// repItemColIDHyperlinkEdit
			// 
			this.repItemColIDHyperlinkEdit.AutoHeight = false;
			this.repItemColIDHyperlinkEdit.Image = ((System.Drawing.Image)(resources.GetObject("repItemColIDHyperlinkEdit.Image")));
			this.repItemColIDHyperlinkEdit.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.repItemColIDHyperlinkEdit.Name = "repItemColIDHyperlinkEdit";
			this.repItemColIDHyperlinkEdit.ReadOnly = true;
			this.repItemColIDHyperlinkEdit.SingleClick = true;
			// 
			// repositoryItemPictureEdit1
			// 
			this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
			// 
			// treeListPopUpMenuImageCollection
			// 
			this.treeListPopUpMenuImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("treeListPopUpMenuImageCollection.ImageStream")));
			this.treeListPopUpMenuImageCollection.Images.SetKeyName(0, "add_16x16.png");
			this.treeListPopUpMenuImageCollection.Images.SetKeyName(1, "remove_16x16.png");
			// 
			// testConnectionImageCollection
			// 
			this.testConnectionImageCollection.ImageSize = new System.Drawing.Size(64, 64);
			this.testConnectionImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("testConnectionImageCollection.ImageStream")));
			this.testConnectionImageCollection.Images.SetKeyName(0, "refresh_32x32.png");
			this.testConnectionImageCollection.Images.SetKeyName(1, "apply_32x32.png");
			this.testConnectionImageCollection.Images.SetKeyName(2, "cancel_32x32.png");
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.ItemLinks.Add(this.btnSelectConnection);
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.ShowCaptionButton = false;
			// 
			// btnSelectConnection
			// 
			this.btnSelectConnection.Caption = "Select connection";
			this.btnSelectConnection.Id = 58;
			this.btnSelectConnection.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectConnection.ImageOptions.Image")));
			this.btnSelectConnection.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSelectConnection.ImageOptions.LargeImage")));
			this.btnSelectConnection.Name = "btnSelectConnection";
			this.btnSelectConnection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSelectConnection_ItemClick);
			// 
			// ReportGeneratorMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 599);
			this.Controls.Add(this.treeList);
			this.Controls.Add(this.ribbonStatusBar);
			this.Controls.Add(this.ribbonControl);
			this.Name = "ReportGeneratorMainForm";
			this.Ribbon = this.ribbonControl;
			this.StatusBar = this.ribbonStatusBar;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportGeneratorMainForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.testResultForReportBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemTestSuiteID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.templateFileRepItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemTFSAddress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemProjectName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.testConnectionRepItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbTemplates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.templateInfoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IReportItemBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeListNodeTypesImageCollection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repItemColIDHyperlinkEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeListPopUpMenuImageCollection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.testConnectionImageCollection)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageGroupTCLoad;
        private DevExpress.XtraBars.BarButtonItem bbiGenerateReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageGroupExport;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource testResultForReportBindingSource;
        private DevExpress.XtraBars.BarEditItem beTestSuiteId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repItemTestSuiteID;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonTemplate;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup templatesRibbonPageGroup;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbTemplates;
		private DevExpress.XtraBars.BarEditItem beTemplateFile;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit templateFileRepItem;
		private System.Windows.Forms.BindingSource templateInfoBindingSource;
		private System.Windows.Forms.BindingSource IReportItemBindingSource;
		private DevExpress.Utils.ImageCollection treeListNodeTypesImageCollection;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colParentID;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colCaption;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colTestOutcome;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colTestedBy;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colTestedDate;
		private DevExpress.XtraTreeList.TreeList treeList;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private DevExpress.Utils.ImageCollection treeListPopUpMenuImageCollection;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.BarEditItem beTFSAddress;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repItemTFSAddress;
		private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
		private DevExpress.XtraBars.BarEditItem beProjectName;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repItemProjectName;
		private DevExpress.XtraBars.BarButtonItem barButtonItem3;
		private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel repositoryItemHypertextLabel1;
		private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colURL;
		private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repItemColIDHyperlinkEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit testConnectionRepItem;
		private DevExpress.XtraBars.BarEditItem testConnectionBarItem;
		private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
		private DevExpress.Utils.ImageCollection testConnectionImageCollection;
		private DevExpress.XtraBars.BarButtonItem btnSelectConnection;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
	}
}