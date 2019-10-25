using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ReportGenerator
{
	public class DummyTestSuiteForReportProvider : ITestSuiteForReportProvider
	{
		private readonly Random _rand = new Random();

		public TestSuiteForReport GetData(uint testSuiteId, CancellationToken cancellationToken, IProgress<string> progress)
		{
			return new TestSuiteForReport(testSuiteId, 333, "DummyTestSuite", GetTestResults(cancellationToken, progress).ToList());
		}

		private IEnumerable<TestResultForReport> GetTestResults(CancellationToken cancellationToken, IProgress<string> progress)
		{
			var count = 150;
			for (int i = 1; i <= count; i++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				progress.Report($"Working on item {i} / {count}");
				Thread.Sleep(30);
				yield return CreateDummyTestResult(progress);
			}
		}

		private TestResultForReport CreateDummyTestResult(IProgress<string> progress)
		{
			var testCaseNo = _rand.Next(0, 99999);
			return new TestResultForReport(testCaseNo, $"dummy title for TC {testCaseNo}", "summ", GetRandomOutcome(), _rand.Next(0, 6666660), _rand.Next(0, 999), "dummy tester", "config", "some guy", DateTime.Now, TimeSpan.FromSeconds(_rand.Next(0, 200)));
		}

		private TestOutcome GetRandomOutcome()
		{
			var randNo = _rand.Next(0, 2);
			if (randNo == 0)
			{
				return TestOutcome.Failed;
			}
			else if (randNo == 1)
			{
				return TestOutcome.Passed;
			}

			return TestOutcome.None;
		}
	}
}
