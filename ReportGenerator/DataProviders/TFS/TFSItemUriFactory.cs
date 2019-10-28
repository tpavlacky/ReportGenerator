using System;

namespace ReportGenerator
{
	internal class TFSItemUriFactory : IUriFactory
	{
		private readonly IConnectionSettings _connectionSettings;

		public TFSItemUriFactory(IConnectionSettings connectionSettings)
		{
			_connectionSettings = connectionSettings ?? throw new ArgumentNullException(nameof(connectionSettings));
		}

		public Uri GetTestPlanUri(int testPlanID)
		{
			return new Uri($"{_connectionSettings.Uri}{_connectionSettings.ProjectName}/_testManagement?planId={testPlanID}");
		}

		public Uri GetTestSuiteUri(int testSuiteID, int? testPlanID)
		{
			return new Uri($"{_connectionSettings.Uri}{_connectionSettings.ProjectName}/_testManagement?suiteId={testSuiteID}" + testPlanID == null ? string.Empty : $"&planId={testPlanID}");
		}

		public Uri GetTestCaseUri(int testCaseID)
		{
			return new Uri($"{_connectionSettings.Uri}{_connectionSettings.ProjectName}/_workitems?_a=edit&id={testCaseID}");
		}

		public Uri GetTestRunUri(int testRunID, int testResultID)
		{
			return new Uri($"{_connectionSettings.Uri}{_connectionSettings.ProjectName}/_TestManagement/Runs?_a=resultSummary&runId={testRunID}&resultId={testResultID}");
		}
	}
}
