using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ReportGenerator.DataProviders.TFSTestSuiteDataProvider
{
	internal class TFSReportItemsProvider : IReportItemsProvider
	{
		private readonly IConnectionSettings _connectionSettings;

		public TFSReportItemsProvider(IConnectionSettings connectionSettings)
		{
			_connectionSettings = connectionSettings ?? throw new ArgumentNullException(nameof(connectionSettings));
		}

		public IList<IReportItem> GetData(uint testItemID, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var teamProject = GetTeamProject(progress);

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

				return new List<IReportItem> { LoadTestSuite(teamProject, staticTestSuite) };
			}
			else
			{
				return new List<IReportItem> { LoadTestPlan(teamProject, testPlan) };
			}
		}

		private ITestManagementTeamProject GetTeamProject(IProgress<string> progress)
		{
			var tfsCollection = InitializeTFSCollection(progress);
			var testManagementService = tfsCollection.GetService<ITestManagementService>();
			ReportProgress(progress, $"Loading project '{_connectionSettings.ProjectName}'");
			var teamProject = testManagementService.GetTeamProject(_connectionSettings.ProjectName);

			if (teamProject == null)
			{
				throw new Exception($"Cannot find project with name: '{_connectionSettings.ProjectName}'");
			}

			return teamProject;
		}

		private TfsTeamProjectCollection InitializeTFSCollection(IProgress<string> progress)
		{
			ReportProgress(progress, $"Connecting to {_connectionSettings.Uri} ...");
			var tfsCollection = new TfsTeamProjectCollection(_connectionSettings.Uri);
			tfsCollection.EnsureAuthenticated();
			return tfsCollection;
		}

		private IReportItem LoadTestPlan(ITestManagementTeamProject teamProject, ITestPlan rootTestPlan)
		{
			var testPlan = new TestPlan(rootTestPlan.Id, 0, rootTestPlan.Name, new Uri("http://www.google.cz"));
			var rootSuite = rootTestPlan.RootSuite;
			if(rootSuite == null)
			{
				return testPlan;
			}

			InitializeTestSuite(teamProject, rootSuite, testPlan);
			return testPlan;

		}

		private IReportItem LoadTestSuite(ITestManagementTeamProject teamProject, IStaticTestSuite rootTestSuite)
		{
			var testSuite = new TestSuite(rootTestSuite.Id, 0, rootTestSuite.Title, new Uri("http://www.idnes.cz"));
			InitializeTestSuite(teamProject, rootTestSuite, testSuite);

			return testSuite;
		}

		private void InitializeTestSuite(ITestManagementTeamProject teamProject, IStaticTestSuite parentStaticTestSuite, IReportItem parentReportItem)
		{
			LoadTestCasesForTestSuite(teamProject, parentStaticTestSuite, parentReportItem);

			foreach (var staticTestSuite in parentStaticTestSuite.SubSuites.OfType<IStaticTestSuite>())
			{
				var reportTestSuite = new TestSuite(staticTestSuite.Id, parentStaticTestSuite.Id, staticTestSuite.Title, new Uri("http://www.seznam.cz"));
				parentReportItem.Children.Add(reportTestSuite);

				InitializeTestSuite(teamProject, staticTestSuite, reportTestSuite);
			}
		}

		private void LoadTestCasesForTestSuite(ITestManagementTeamProject teamProject, IStaticTestSuite staticParentTestSUite, IReportItem parentReportItem)
		{
			var testCases = staticParentTestSUite.TestCases;
			foreach (var testEntry in testCases)
			{
				var testResult = teamProject.TestResults.ByTestId(testEntry.Id).OrderByDescending(c => c.DateCreated).FirstOrDefault();
				if(testResult == null)
				{
					parentReportItem.Children.Add(
						new TestCase(
							testEntry.Id, 
							staticParentTestSUite.Id, 
							testEntry.Title,
							testEntry.TestCase?.Description));
				}
				else
				{
					parentReportItem.Children.Add(
						new TestCase(
							testEntry.Id,
							staticParentTestSUite.Id,
							testEntry.Title,
							testEntry.TestCase?.Description,
							testResult.Outcome,
							testResult.RunByName,
							testResult.DateCompleted,
							new Uri("http://wwww.idnes.cz"),
							testResult.TestConfigurationName,
							testResult.Duration,
							testResult.TestRunId,
							testResult.TestResultId));
				}
			}
		}

		private void ReportProgress(IProgress<string> progress, string message)
		{
			progress?.Report(message);
		}

		//public TestSuiteForReport GetData(uint objectID, CancellationToken cancellationToken, IProgress<string> progress)
		//{
		//	var results = new List<TestResultForReport>();
		//	var tfsCollection = new TfsTeamProjectCollection(
		//		new Uri("https://tfs.dev.its:8090/tfs/Office%204.6/"));
		//	tfsCollection.EnsureAuthenticated();

		//	var testManagementService = tfsCollection.GetService<ITestManagementService>();
		//	var teamProject = testManagementService.GetTeamProject("TP DCMS2");

		//	var testSuite = teamProject.TestSuites.Find((int)objectID);
		//	var testSuiteName = testSuite.Title;
		//	var testCases = testSuite.AllTestCases;
		//	var testCasesCount = testCases.Count;
		//	var actualTestCase = 0;
		//	foreach (var testCase in testCases)
		//	{
		//		actualTestCase++;
		//		cancellationToken.ThrowIfCancellationRequested();
		//		progress.Report($"Loading test case {actualTestCase}/{testCasesCount}...");
		//		var testResult = teamProject.TestResults.ByTestId(testCase.Id).OrderByDescending(c => c.DateCreated).FirstOrDefault();
		//		results.Add(new TestResultForReport(testCase.Id, testCase.Title, testCase.Description, testResult.Outcome, testResult.TestResultId, testResult.TestRunId, testCase.OwnerName, testResult.TestConfigurationName, testResult.RunByName, testResult.DateCompleted, testResult.Duration));
		//	}

		//	return new TestSuiteForReport(objectID, testSuite.Plan.Id, testSuiteName, results);
		//}

	}
}
