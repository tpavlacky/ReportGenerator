using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ReportGenerator.DataProviders.TFSTestSuiteDataProvider
{
	public class TFSPlanTestSuiteProvider : ITestSuiteForReportProvider
	{
		public TestSuiteForReport GetData(uint objectID, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var results = new List<TestResultForReport>();
			var tfsCollection = new TfsTeamProjectCollection(
				new Uri("https://tfs.dev.its:8090/tfs/Office%204.6/"));
			tfsCollection.EnsureAuthenticated();

			var testManagementService = tfsCollection.GetService<ITestManagementService>();
			var teamProject = testManagementService.GetTeamProject("TP DCMS2");

			var testSuite = teamProject.TestSuites.Find((int)objectID);
			var testSuiteName = testSuite.Title;
			var testCases = testSuite.AllTestCases;
			var testCasesCount = testCases.Count;
			var actualTestCase = 0;
			foreach (var testCase in testCases)
			{
				actualTestCase++;
				cancellationToken.ThrowIfCancellationRequested();
				progress.Report($"Loading test case {actualTestCase}/{testCasesCount}...");
				var testResult = teamProject.TestResults.ByTestId(testCase.Id).OrderByDescending(c => c.DateCreated).FirstOrDefault();
				results.Add(new TestResultForReport(testCase.Id, testCase.Title, testCase.Description, testResult.Outcome, testResult.TestResultId, testResult.TestRunId, testCase.OwnerName, testResult.TestConfigurationName, testResult.RunByName, testResult.DateCompleted, testResult.Duration));
			}

			return new TestSuiteForReport(objectID, testSuite.Plan.Id, testSuiteName, results);
		}
	}
}
