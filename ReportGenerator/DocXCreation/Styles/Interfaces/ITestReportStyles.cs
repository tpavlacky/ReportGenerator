namespace ReportGenerator.DocXCreation
{
	public interface ITestReportStyles
	{
		IDocStyle Default { get; }

		IDocStyle TestSuiteHeader { get; }

		IDocStyle TestCaseHeader { get; }

		IDocStyle SummaryHeader { get; }

		IDocStyle PassedTestCase { get; }

		IDocStyle FailedTestCase { get; }
	}
}
