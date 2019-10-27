using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ReportGenerator.Model;
using Xceed.Document.NET;

namespace ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders
{
	internal class XCeedTestSuiteBlockBuilder : BlockBuilder
	{
		public XCeedTestSuiteBlockBuilder(Document document) : base(document)
		{
		}

		public override void Build(IReportItem reportItem, uint level, CancellationToken cancellationToken, IProgress<string> progress)
		{
			//TODO remove and create separate builder if necessary
			if (reportItem is TestPlan)
			{
				return;
			}

			AppendTestSuiteHeader(reportItem, level);
			AppendTestCasesCountSection(reportItem);
		}

		private void AppendTestCasesCountSection(IReportItem reportItem)
		{
			var testCases = reportItem.Children.OfType<TestCase>().ToList();
			if (testCases.Count == 0)
			{
				return;
			}

			AppendHorizontalLine();
			AppendTestCasesCount(testCases.Count);
			AppendHorizontalLine();
		}

		private void AppendTestSuiteHeader(IReportItem reportItem, uint level)
		{
			var par = _document
				.InsertParagraph("Test suite ")
				.AppendHyperlink(CreateHyperLink(reportItem.ID.ToString(), reportItem.URI))
				.Append($": {reportItem.Caption}")
				.KeepWithNextParagraph();

			par.StyleName = GetTestSuiteHeaderStyle(level);
		}

		private void AppendTestCasesCount(int testCasesCount)
		{
			var par = _document
				.InsertParagraph($"Test cases ({testCasesCount})")
				.KeepWithNextParagraph();
		}

		private void AppendHorizontalLine()
		{
			var par = _document.InsertParagraph();
			par.InsertHorizontalLine(HorizontalBorderPosition.top);
			par.KeepWithNextParagraph();
		}

		private string GetTestSuiteHeaderStyle(uint hierarchyLevel)
		{
			if(hierarchyLevel == 1)
			{
				return StyleNames.TEST_SUITE_1;
			}

			if(hierarchyLevel == 2)
			{
				return StyleNames.TEST_SUITE_2;
			}

			if(hierarchyLevel == 3)
			{
				return StyleNames.TEST_SUITE_3;
			}

			if(hierarchyLevel == 4)
			{
				return StyleNames.TEST_SUITE_4;
			}

			return StyleNames.TEST_SUITE_4;
		}
	}
}
