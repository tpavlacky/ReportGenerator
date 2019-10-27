using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.TeamFoundation.TestManagement.Client;
using ReportGenerator.Model;
using Xceed.Document.NET;

namespace ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders
{
	internal class XCeedTestCaseBlockBuilder : BlockBuilder
	{
		private const string SUMMARY_HEADER_CAPTION = "SUMMARY";
		private const string LATEST_TEST_OUTCOME_HEADER_CAPTION = "LATEST TEST OUTCOME";
		private const string OUTCOME_DATETIME_FORMAT = "dd. MMMM yyyy";
		private const int OUTCOME_TABLE_ROWS = 2;

		public XCeedTestCaseBlockBuilder(Document document) : base(document)
		{
		}

		public override void Build(IReportItem reportItem, uint level, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var testCase = reportItem as TestCase;
			if(testCase == null)
			{
				//ex
				return;
			}

			AppendTestCaseHeader(testCase);
			AppendSummaryHeader();
			AppendExpectedResult(testCase);
			AppendLatestTestOutcomeHeader();
			AppendLatestTestOutcomeOverview(testCase);
		}

		private void AppendTestCaseHeader(IReportItem reportItem)
		{
			var par = _document
				.InsertParagraph("Test case ")
				.AppendHyperlink(CreateHyperLink(reportItem.ID.ToString(), reportItem.URI))
				.Append($": {reportItem.Caption}")
				.KeepWithNextParagraph();
			par.StyleName = StyleNames.TEST_CASE_HEADER;
		}

		private void AppendSummaryHeader()
		{
			var par = _document
				.InsertParagraph(SUMMARY_HEADER_CAPTION)
				.KeepWithNextParagraph();
			par.StyleName = StyleNames.SUMMARY_HEADER;
		}

		private void AppendExpectedResult(IReportItem reportItem)
		{
			_document
				.InsertParagraph(reportItem.Summary);
		}

		private void AppendLatestTestOutcomeHeader()
		{
			var par = _document
				.InsertParagraph(LATEST_TEST_OUTCOME_HEADER_CAPTION)
				.KeepWithNextParagraph();
			par.StyleName = StyleNames.SUMMARY_HEADER;
		}

		private void AppendLatestTestOutcomeOverview(TestCase testCase)
		{
			var tableDescriptors = GetTableDescriptors(testCase);
			var tableDescriptorsCount = tableDescriptors.Count;
			if (tableDescriptorsCount == 0)
			{
				return;
			}

			var table = _document.AddTable(OUTCOME_TABLE_ROWS, tableDescriptorsCount);
			SetTableFormat(table);
			var outcomeContentTableStyle = GetTestOutcomeFont(testCase.TestOutcome);

			for (int i = 0; i < tableDescriptorsCount; i++)
			{
				var tableDescriptor = tableDescriptors[i];
				var header = table.Rows[0].Cells[i].Paragraphs
					.First()
					.Append(tableDescriptor.Caption)
					.KeepLinesTogether()
					.KeepWithNextParagraph();
				var contentCell = table.Rows[1].Cells[i].Paragraphs.First();

				if (tableDescriptor.CellTextType == OutcomeCellTextType.Text)
				{
					contentCell.Append(tableDescriptor.Text);
					contentCell.StyleName = outcomeContentTableStyle;
				}
				else if (tableDescriptor.CellTextType == OutcomeCellTextType.Hyperlink)
				{
					var hyperLink = CreateHyperLink(testCase.TestOutcome.ToString(), testCase.URI);
					contentCell.AppendHyperlink(hyperLink);
				}
				else
				{
					contentCell.Append(tableDescriptor.Text);
				}
			}
			_document.InsertTable(table);
			_document.InsertParagraph();
		}

		private static void SetTableFormat(Table table)
		{
			table.Alignment = Alignment.left;
			table.Design = TableDesign.None;
		}

		private List<OutcomeTableDescriptor> GetTableDescriptors(TestCase testCase)
		{
			return new List<OutcomeTableDescriptor>
			{
				new OutcomeTableDescriptor("Outcome", testCase.TestOutcome.ToString(), OutcomeCellTextType.Hyperlink),
				new OutcomeTableDescriptor("Configuration", testCase.Configuration),
				new OutcomeTableDescriptor("Run by", testCase.TestedBy),
				new OutcomeTableDescriptor("Date completed", testCase.TestedDate?.ToString(OUTCOME_DATETIME_FORMAT)),
				new OutcomeTableDescriptor("Duration in seconds", testCase.Duration.ToString())
			};
		}

		private string GetTestOutcomeFont(TestOutcome? outcome)
		{
			switch (outcome)
			{
				case TestOutcome.Passed:
					return StyleNames.TC_PASSED;
				case TestOutcome.Failed:
					return StyleNames.TC_FAILED;
				default:
					return StyleNames.DEFAULT;
			}
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

		private enum OutcomeCellTextType
		{
			Text,
			Hyperlink
		}
	}
}
