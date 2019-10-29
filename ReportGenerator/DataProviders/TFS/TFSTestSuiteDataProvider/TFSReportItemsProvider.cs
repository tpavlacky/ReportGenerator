using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.TeamFoundation.TestManagement.Client;
using ReportGenerator.Extenders;
using ReportGenerator.Model;

namespace ReportGenerator.DataProviders.TFS.TFSTestSuiteDataProvider
{
	internal class TFSReportItemsProvider : IReportItemsProvider
	{
		public IList<IReportItem> GetData(ITestManagementTeamProject teamProject, IUriFactory uriFactory, uint testItemID, CancellationToken cancellationToken, IProgress<string> progress)
		{
			ReportProgress(progress, $"Looking for test plan with ID {testItemID} ...");
			var testPlan = teamProject.TestPlans.Find((int)testItemID);
			if (testPlan == null)
			{
				ReportProgress(progress, $"Test plan with ID {testItemID} not found ...");
				Thread.Sleep(500);

				ReportProgress(progress, $"Trying to find test suite with ID {testItemID} ...");
				var testSuite = teamProject.TestSuites.Find((int)testItemID);
				if (testSuite == null)
				{
					ReportProgress(progress, $"Test suite with ID {testItemID} not found ...");
					Thread.Sleep(500);
					return new List<IReportItem>(0);
				}

				if(!(testSuite is IStaticTestSuite staticTestSuite))
				{
					return new List<IReportItem>(0);
				}

				return new List<IReportItem> { LoadTestSuite(teamProject, uriFactory, staticTestSuite, cancellationToken, progress) };
			}
			else
			{
				return new List<IReportItem> { LoadTestPlan(teamProject, uriFactory, testPlan, cancellationToken, progress) };
			}
		}


		private IReportItem LoadTestPlan(ITestManagementTeamProject teamProject, IUriFactory uriFactory, ITestPlan rootTestPlan, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var testPlan = new TestPlan(rootTestPlan.Id, 0, rootTestPlan.Name, uriFactory.GetTestPlanUri(rootTestPlan.Id));
			var rootSuite = rootTestPlan.RootSuite;
			if(rootSuite == null)
			{
				return testPlan;
			}

			ReportProgress(progress, $"Loading test plan {rootTestPlan.Id} ...");
			InitializeTestSuite(teamProject, uriFactory, rootSuite, testPlan, cancellationToken, progress);
			return testPlan;

		}

		private IReportItem LoadTestSuite(ITestManagementTeamProject teamProject, IUriFactory uriFactory, IStaticTestSuite rootTestSuite, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var testSuite = new TestSuite(rootTestSuite.Id, 0, rootTestSuite.Title, uriFactory.GetTestSuiteUri(rootTestSuite.Id, rootTestSuite.Plan?.Id));
			ReportProgress(progress, $"Loading test suite {rootTestSuite.Id} ...");
			InitializeTestSuite(teamProject, uriFactory, rootTestSuite, testSuite, cancellationToken, progress);

			return testSuite;
		}

		private void InitializeTestSuite(ITestManagementTeamProject teamProject, IUriFactory uriFactory, IStaticTestSuite parentStaticTestSuite, IReportItem parentReportItem, CancellationToken cancellationToken, IProgress<string> progress)
		{
			LoadTestCasesForTestSuite(teamProject, uriFactory, parentStaticTestSuite, parentReportItem, cancellationToken, progress);

			foreach (var staticTestSuite in parentStaticTestSuite.SubSuites.OfType<IStaticTestSuite>().OrderBy(suite => suite.Title))
			{
				ReportProgress(progress, $"Loading test suite {staticTestSuite.Id} ...");
				cancellationToken.ThrowIfCancellationRequested();
				var reportTestSuite = new TestSuite(staticTestSuite.Id, parentStaticTestSuite.Id, staticTestSuite.Title, uriFactory.GetTestSuiteUri(staticTestSuite.Id, staticTestSuite.Plan?.Id));
				parentReportItem.Children.Add(reportTestSuite);

				InitializeTestSuite(teamProject, uriFactory, staticTestSuite, reportTestSuite, cancellationToken, progress);
			}
		}

		private void LoadTestCasesForTestSuite(ITestManagementTeamProject teamProject, IUriFactory uriFactory, IStaticTestSuite staticParentTestSUite, IReportItem parentReportItem, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var testCases = staticParentTestSUite.TestCases;
			var actualTestCase = 0;
			var testCasesCount = testCases.Count;
			foreach (var testEntry in testCases)
			{
				actualTestCase++;
				ReportProgress(progress, $"Loading test cases for test suite {staticParentTestSUite.Id} ({actualTestCase}/{testCasesCount}) ...");
				cancellationToken.ThrowIfCancellationRequested();
				var testResult = teamProject.TestResults.ByTestId(testEntry.Id).OrderByDescending(c => c.DateCreated).FirstOrDefault();
				if(testResult == null)
				{
					parentReportItem.Children.Add(
						new TestCase(
							testEntry.Id, 
							staticParentTestSUite.Id, 
							testEntry.Title,
              testEntry.TestCase?.Description.HtmlToPlainText()));
				}
				else
        {
          var testCaseUri = IsValidTestOutcome(testResult) ? uriFactory.GetTestCaseUri(testEntry.Id) : null;
          var testRunUri = IsValidTestOutcome(testResult) ? uriFactory.GetTestRunUri(testResult.TestRunId, testResult.TestResultId) : null;

          parentReportItem.Children.Add(
						new TestCase(
							testEntry.Id,
							staticParentTestSUite.Id,
							testEntry.Title,
							testEntry.TestCase?.Description.HtmlToPlainText(),
							testResult.Outcome,
							testResult.RunByName,
							testResult.DateCompleted,
              testCaseUri,
              testRunUri,
							testResult.TestConfigurationName,
							testResult.Duration));
				}
			}
		}

    private bool IsValidTestOutcome(ITestCaseResult testCaseResult)
    {
      return testCaseResult.Outcome != TestOutcome.NotExecuted;
    }

		private void ReportProgress(IProgress<string> progress, string message)
		{
			progress?.Report(message);
		}
	}
}
