using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace ReportGenerator.DataProviders.Dummy.Hierarchy
{
	public class DummyHierarchyForReportProvider : ITestPlanForReportProvider
	{
		private Random _random = new Random();

		public IList<IReportItem> GetData(uint testSuiteID, CancellationToken cancellationToken, IProgress<string> progress)
		{
			return new List<IReportItem>{new TestPlan(0, 0, "Regression dummy test plan", null, string.Empty, null, new List<IReportItem>
			{
				CreateTestSuite(1, 0,
					new List<IReportItem>
					{
						//CreateTestCase(14, 0),
						CreateTestSuite(11, 1, new List<IReportItem>
						{
							CreateTestCase(111, 11),
							CreateTestCase(112, 11),
							CreateTestCase(113, 11),
						}),
						CreateTestCase(12, 0),
						CreateTestCase(13, 0),
						CreateTestCase(14, 0),
						CreateTestCase(15, 0),
						CreateTestCase(16, 0),
						CreateTestCase(17, 0),
						CreateTestCase(18, 0),
						CreateTestCase(19, 0),
						CreateTestCase(20, 0),
					}),
				CreateTestSuite(2, 0, new List<IReportItem>
				{
					CreateTestSuite(21, 2, new List<IReportItem>()
					{
						CreateTestCase(211, 21),
						CreateTestCase(212, 21)
					}),
					CreateTestSuite(22, 2, new List<IReportItem>
					{
						CreateTestCase(221, 22)
					})
				}),
				CreateTestSuite(3, 0, new List<IReportItem>
				{
					CreateTestSuite(31, 3),
					CreateTestSuite(32, 3),
					CreateTestSuite(33, 3, new List<IReportItem>
					{
						CreateTestCase(331, 33)
					}),
				}),
				CreateTestSuite(4, 0, new List<IReportItem>
				{
					CreateTestSuite(41, 4),
					CreateTestSuite(42, 4),
					CreateTestSuite(43, 4, new List<IReportItem>
					{
						CreateTestCase(431, 43)
					}),
				})}, new Uri("http://www.google.com"))};
		}



		private TestSuite CreateTestSuite(int id, int parentID)
		{
			return CreateTestSuite(id, parentID, new List<IReportItem>(0));
		}

		private TestSuite CreateTestSuite(int id, int parentID, IList<IReportItem> items)
		{
			return new TestSuite(id, parentID, $"Dummy test suite {id}", null, string.Empty, null, items, new Uri("http://www.seznam.cz"));
		}

		//private void AddTestCase(TestSuite testSuite, int testCaseID)
		//{
		//	testSuite.Children.Add(CreateTestCase(testCaseID, testSuite.ID));
		//}

		private TestCase CreateTestCase(int id, int parentID)
		{
			return new TestCase(id, parentID, $"Caption for TC {id}", GetRandomTestOutcome(), "Tested by someone", DateTime.Now, new List<IReportItem>(0), new Uri("http://www.idnes.cz"));
		}

		private TestOutcome GetRandomTestOutcome()
		{
			var value = _random.Next(0, 5);
			return (TestOutcome)value;
		}
	}
}
