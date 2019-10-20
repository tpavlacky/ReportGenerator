using System.Drawing;
using ReportGenerator.Extenders;
using Spire.Doc;
using Spire.Doc.Documents;

namespace ReportGenerator.DocXCreation
{
  internal class TestSuiteBlockBuilder : BlockBuilderBase
  {
    private const string TEST_SUITE_ADDRESS_TEMPLATE = "https://tfs.dev.its:8090/tfs/Office%204.6/TP%20DCMS2/PLAN/_testManagement?suiteId={0}&planId={1}";

    public TestSuiteBlockBuilder(Section section)
      : base(section)
    {
    }

    public void AppendTestSuiteInformation(TestSuiteForReport testSuite)
    {
      AppendTestSuiteTitle();
			AppendHorizontalLine();
			AppendTestCasesCount();
      AppendHorizontalLine();

      void AppendTestSuiteTitle()
      {
        var par = _section.AddParagraph();
        par.AppendText("Test suite");
        AppendHyperlink(par, CreateTestSuiteHyperlink(testSuite));
        par.AppendText($": {testSuite.TestSuiteCaption}");
				par.ApplyStyle(StyleNames.HEADING_1);
				//par.ApplyStyleSafe(nameof(_testReportStyles.TestSuiteHeader));
      }

      void AppendTestCasesCount()
      {
        var testCasesCountPar = _section.AddParagraph();
        testCasesCountPar.AppendText($"Test cases ({testSuite.TestResults.Count})");
      }
    }

    private void AppendHorizontalLine()
    {
      var par = _section.AddParagraph();
      var shape = par.AppendShape(_section.PageSetup.ClientWidth, 1, ShapeType.Line);
      shape.StrokeColor = Color.Gray;
      shape.StrokeWeight = 1;
    }

    private WorkItemHyperlink CreateTestSuiteHyperlink(TestSuiteForReport testSuiteForReport)
    {
      var workItemLink = string.Format(TEST_SUITE_ADDRESS_TEMPLATE, testSuiteForReport.TestSuiteID, testSuiteForReport.TestPlanID);
      return new WorkItemHyperlink(testSuiteForReport.TestSuiteID.ToString(), workItemLink);
    }

  }
}