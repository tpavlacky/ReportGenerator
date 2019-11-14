using ReportGenerator.Settings;
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
			return new Uri(Uri.EscapeDataString(GetBaseAddress() + $"/_testManagement?planId={testPlanID}"));
		}

		public Uri GetTestSuiteUri(int testSuiteID, int? testPlanID)
		{
			var testPlanPart = testPlanID == null ? string.Empty : $"&planId={testPlanID}";
			return new Uri(Uri.EscapeDataString(GetBaseAddress() + $"/_testManagement?suiteId={testSuiteID}" + testPlanPart));
		}

		public Uri GetTestCaseUri(int testCaseID)
		{
			return new Uri(Uri.EscapeDataString(GetBaseAddress() + $"/_workitems?_a=edit&id={testCaseID}"));
		}

		public Uri GetTestRunUri(int testRunID, int testResultID)
		{
			return new Uri(Uri.EscapeDataString(GetBaseAddress() + $"/_TestManagement/Runs?_a=resultSummary&runId={testRunID}&resultId={testResultID}"));
		}

		private string GetBaseAddress()
		{
			var separator = _connectionSettings.Uri.AbsoluteUri.EndsWith("/") ? string.Empty : "/";
			return _connectionSettings.Uri + separator + _connectionSettings.ProjectName;
		}
	}
}
