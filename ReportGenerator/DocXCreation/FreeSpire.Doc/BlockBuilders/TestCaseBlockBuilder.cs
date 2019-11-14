using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.TeamFoundation.TestManagement.Client;
using ReportGenerator.DocXCreation.Styles;
using ReportGenerator.Extenders;
using Spire.Doc;
using Spire.Doc.Documents;

namespace ReportGenerator.DocXCreation
{
  internal class TestCaseBlockBuilder : BlockBuilderBase
    {
    private const string WORK_ITEM_ADDRESS = "https://tfs.dev.its:8090/tfs/Office%204.6/TP%20DCMS2/PLAN/_workitems?_a=edit&id=";
    private const string TEST_RUN_ADDRESS_TEMPLATE = "https://tfs.dev.its:8090/tfs/Office%204.6/TP%20DCMS2/PLAN/_TestManagement/Runs?_a=resultSummary&runId={0}&resultId={1}";

    private const string SUMMARY_HEADER_CAPTION = "SUMMARY";
    private const string LATEST_TEST_OUTCOME_HEADER_CAPTION = "LATEST TEST OUTCOME";
    private const string OUTCOME_DATETIME_FORMAT = "dd. MMMM yyyy";

    private const int OUTCOME_TABLE_ROWS = 2;


    private enum OutcomeCellTextType
    {
      Text,
      Hyperlink
    }

    public TestCaseBlockBuilder(Section section)
      : base(section)
    {
    }

    public void Build(TestSuiteForReport testSuite, TestResultForReport testResult)
    {
      AppendTestCaseHeader(testResult);
      AppendSummaryHeader();
      AppendExpectedResult(testResult);
      AppendLatestTestOutcomeHeader();
      AppendLatestTestOutcomeOverview(testResult);
    }

    private void AppendTestCaseHeader(TestResultForReport testResult)
    {
      var par = _section.AddParagraph();
      par.AppendText("Test case ");
      AppendHyperlink(par, CreateWorkItemHyperlink(testResult.TestCaseId));
      par.AppendText($": {testResult.Title}");
			par.ApplyStyleSafe(StyleNames.TEST_CASE_HEADER);
			//par.ApplyStyleSafe(nameof(_testReportStyles.TestCaseHeader));
			par.Format.KeepFollow = true;
    }

    private void AppendSummaryHeader()
    {
      var par = _section.AddParagraph();
      par.AppendText(SUMMARY_HEADER_CAPTION);
			par.ApplyStyleSafe(StyleNames.SUMMARY_HEADER);
			//par.ApplyStyleSafe(nameof(_testReportStyles.SummaryHeader));
			par.Format.KeepFollow = true;
    }

    private void AppendLatestTestOutcomeHeader()
    {
      var par = _section.AddParagraph();
      par.AppendText(LATEST_TEST_OUTCOME_HEADER_CAPTION);
			par.ApplyStyleSafe(StyleNames.SUMMARY_HEADER);
			//par.ApplyStyleSafe(nameof(_testReportStyles.SummaryHeader));
			par.Format.KeepFollow = true;
    }

    private void AppendExpectedResult(TestResultForReport testResult)
    {
      var par = _section.AddParagraph();
      par.AppendText(testResult.Summary);
    }

    private void AppendLatestTestOutcomeOverview(TestResultForReport testResult)
    {
      var tableDescriptors = GetTableDescriptors(testResult);
      var tableDescriptorsCount = tableDescriptors.Count;
      if (tableDescriptorsCount == 0)
      {
        return;
      }

      var table = _section.AddTable(false);
      table.ResetCells(OUTCOME_TABLE_ROWS, tableDescriptorsCount);
      var headerRow = table.Rows[0];
      SetHeaderRowStyle(headerRow);

      var outcomeContentTableStyle = GetTestOutcomeFont(testResult.Outcome);
      var dataRow = table.Rows[1];
      for (var i = 0; i < tableDescriptorsCount; i++)
      {
        var tableDescriptor = tableDescriptors[i];
        headerRow.Cells[i].AddParagraph().AppendText(tableDescriptor.Caption);
        var dataRowCell = dataRow.Cells[i];
        var contentPar = dataRowCell.AddParagraph();

        FormatTableCell();
        AppendTableContent();
				contentPar.ApplyStyleSafe(outcomeContentTableStyle);
				//contentPar.ApplyStyleSafe(outcomeContentTableStyle);

        void FormatTableCell()
        {
          dataRowCell.CellFormat.VerticalAlignment = VerticalAlignment.Middle;
          contentPar.Format.HorizontalAlignment = HorizontalAlignment.Left;
        }

        void AppendTableContent()
        {
          switch (tableDescriptor.CellTextType)
          {
            case OutcomeCellTextType.Text:
              contentPar.AppendText(tableDescriptor.Text);
              contentPar.ApplyStyleSafe(outcomeContentTableStyle);
              break;
            case OutcomeCellTextType.Hyperlink:
              AppendHyperlink(contentPar, CreateTestResultHyperlink(testResult));
              break;
            default:
              throw new ArgumentOutOfRangeException();
          }
        }
      }
    }

    private List<OutcomeTableDescriptor> GetTableDescriptors(TestResultForReport testResult)
    {
      return new List<OutcomeTableDescriptor>
      {
        new OutcomeTableDescriptor("Outcome", testResult.Outcome.ToString(), OutcomeCellTextType.Hyperlink),
        new OutcomeTableDescriptor("Tester", testResult.Tester),
        new OutcomeTableDescriptor("Configuration", testResult.Configuration),
        new OutcomeTableDescriptor("Run by", testResult.RunBy),
        new OutcomeTableDescriptor("Date completed", testResult.DateCompleted.ToString(OUTCOME_DATETIME_FORMAT)),
        new OutcomeTableDescriptor("Duration in seconds", testResult.DurationInSeconds.TotalSeconds.ToString(CultureInfo.InvariantCulture))
      };
    }

    private string GetTestOutcomeFont(TestOutcome outcome)
    {
      switch (outcome)
      {
        case TestOutcome.Passed:
					return StyleNames.PASSED_TC;
        case TestOutcome.Failed:
					return StyleNames.FAILED_TC;
        default:
					return StyleNames.DEFAULT;
      }
    }

    private static void SetHeaderRowStyle(TableRow header)
    {
      header.IsHeader = true;
      header.HeightType = TableRowHeightType.Auto;
    }

    private WorkItemHyperlink CreateWorkItemHyperlink(int workItemId)
    {
      var workItemLink = WORK_ITEM_ADDRESS + workItemId;
      return new WorkItemHyperlink(workItemId.ToString(), workItemLink);
    }

    private WorkItemHyperlink CreateTestResultHyperlink(TestResultForReport testResult)
    {
      var testResultLink = string.Format(TEST_RUN_ADDRESS_TEMPLATE, testResult.TestRunId, testResult.TestResultId);
      return new WorkItemHyperlink(testResult.Outcome.ToString(), testResultLink);
    }

    private class OutcomeTableDescriptor
    {
      public string Caption { get; }
      public string Text { get; }
      public OutcomeCellTextType CellTextType { get; }

      public OutcomeTableDescriptor(string caption, string text, OutcomeCellTextType cellTextType = OutcomeCellTextType.Text)
      {
        Caption = caption;
        Text = text;
        CellTextType = cellTextType;
      }
    }
  }
}