using System;

namespace ReportGenerator
{
	public interface IUriFactory
	{
		Uri GetTestCaseUri(int testCaseID);
		Uri GetTestPlanUri(int testPlanID);
		Uri GetTestRunUri(int testRunID, int testResultID);
		Uri GetTestSuiteUri(int testSuiteID, int? testPlanID);
	}
}