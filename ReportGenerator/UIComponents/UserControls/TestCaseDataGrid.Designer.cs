namespace ReportGenerator.UIComponents.UserControls
{
	partial class TestCaseDataGrid
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
			this.gridControl = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSummary = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTestCaseId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOutcome = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTestResultId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTestRunId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTester = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colConfiguration = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRunBy = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDateCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDurationInSeconds = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControl
			// 
			this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl.Location = new System.Drawing.Point(0, 0);
			this.gridControl.MainView = this.gridView;
			this.gridControl.Name = "gridControl";
			this.gridControl.Size = new System.Drawing.Size(722, 395);
			this.gridControl.TabIndex = 3;
			this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
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
			formatConditionRuleExpression3.Expression = "[Outcome] = 2";
			formatConditionRuleExpression3.PredefinedName = "Bold Text";
			gridFormatRule3.Rule = formatConditionRuleExpression3;
			gridFormatRule4.Column = this.colOutcome;
			gridFormatRule4.Name = "OutcomeFailed";
			formatConditionRuleExpression4.Expression = "[Outcome] = 3";
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
			// colOutcome
			// 
			this.colOutcome.FieldName = "Outcome";
			this.colOutcome.Name = "colOutcome";
			this.colOutcome.OptionsColumn.ReadOnly = true;
			this.colOutcome.Visible = true;
			this.colOutcome.VisibleIndex = 1;
			this.colOutcome.Width = 69;
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
			// TestCaseDataGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridControl);
			this.Name = "TestCaseDataGrid";
			this.Size = new System.Drawing.Size(722, 395);
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gridControl;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
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
	}
}
