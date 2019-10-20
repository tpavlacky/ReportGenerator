using System.Collections.Generic;

namespace ReportGenerator
{
	public class TestSuiteForReport
	{
		public uint TestSuiteID { get; }
		public int TestPlanID { get; }
		public string TestSuiteCaption { get; set; }

		public ICollection<TestResultForReport> TestResults { get; } = new List<TestResultForReport>();

		public TestSuiteForReport(uint testSuiteId, int testPlanId, string testSuiteCaption, ICollection<TestResultForReport> testResults)
		{
			TestSuiteID = testSuiteId;
			TestPlanID = testPlanId;
			TestSuiteCaption = testSuiteCaption;
			TestResults = testResults;
		}
	}
}