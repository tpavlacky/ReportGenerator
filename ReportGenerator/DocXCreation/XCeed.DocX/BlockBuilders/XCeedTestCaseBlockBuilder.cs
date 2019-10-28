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

		public override void Build(IReportItem reportItem, int level, CancellationToken cancellationToken, IProgress<string> progress)
		{
			if (!(reportItem is TestCase testCase))
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
					.Append(tableDescriptor.ColumnCaption)
					.KeepLinesTogether()
					.KeepWithNextParagraph();
				var contentCell = table.Rows[1].Cells[i].Paragraphs.First();

				if (tableDescriptor is OutcomeTableDescriptor)
				{
					contentCell.Append(tableDescriptor.OutcomeRowText);
					contentCell.StyleName = outcomeContentTableStyle;
				}
				else if (tableDescriptor is OutcomeTableHyperLinkDescriptor hyperLinkDescriptor)
				{
					var hyperLink = CreateHyperLink(hyperLinkDescriptor.OutcomeRowText, hyperLinkDescriptor.Uri);
					contentCell.AppendHyperlink(hyperLink);
				}
				else
				{
					contentCell.Append(tableDescriptor.OutcomeRowText);
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
				new OutcomeTableHyperLinkDescriptor("Outcome", testCase.TestOutcome.ToString(), testCase.TestRunResultUri),
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

		//TODO -> remove definition for column name from this class and separate creation of header cells from content cells
		private class OutcomeTableDescriptor
		{
			public string ColumnCaption { get; }
			public string OutcomeRowText { get; }

			public OutcomeTableDescriptor(string caption, string text)
			{
				ColumnCaption = caption;
				OutcomeRowText = text;
			}
		}

		private class OutcomeTableHyperLinkDescriptor : OutcomeTableDescriptor
		{
			public Uri Uri { get; }

			public OutcomeTableHyperLinkDescriptor(string caption, string text, Uri uri) : base(caption, text)
			{
				Uri = uri;
			}
		}

		private enum OutcomeCellTextType
		{
			Text,
			Hyperlink
		}
	}
}
