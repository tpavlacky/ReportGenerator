using System;
using Microsoft.TeamFoundation.TestManagement.Client;
using ReportGenerator.Extenders;

namespace ReportGenerator
{
	public class TestResultForReport
	{
		public int Id { get; }
		public string Description { get; }
		public int TestCaseId { get; }
		public string Summary { get; }
		public string Title { get; }
		public TestOutcome Outcome { get; }
		public int TestResultId { get; }
		public int TestRunId { get; }
		public string Tester { get; }
		public string Configuration { get; }
		public string RunBy { get; }
		public DateTime DateCompleted { get; }
		public TimeSpan DurationInSeconds { get; }

		public TestResultForReport(int testCaseId, string title, string summary, TestOutcome outcome, int testResultId, int testRunId, string tester, string configuration, string runBy, DateTime dateCompleted, TimeSpan durationInSeconds)
		{
			TestCaseId = testCaseId;
			Summary = summary.HtmlToPlainText();
			Title = title;
			Outcome = outcome;
			TestResultId = testResultId;
			TestRunId = testRunId;
			Tester = tester;
			Configuration = configuration;
			RunBy = runBy;
			DateCompleted = dateCompleted;
			DurationInSeconds = durationInSeconds;
		}
	}
}