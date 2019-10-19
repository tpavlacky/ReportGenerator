using System.Collections.Generic;

namespace ProtocolGenerator
{
	public class TestSuiteForReport
	{
		public int TestSuiteID { get; }
		public int TestPlanID { get; }
		public string TestSuiteCaption { get; set; }

		public ICollection<TestResultForReport> TestResults { get; } = new List<TestResultForReport>();

		public TestSuiteForReport(int testSuiteId, int testPlanId, string testSuiteCaption, ICollection<TestResultForReport> testResults)
		{
			TestSuiteID = testSuiteId;
			TestPlanID = testPlanId;
			TestSuiteCaption = testSuiteCaption;
			TestResults = testResults;
		}
	}
}