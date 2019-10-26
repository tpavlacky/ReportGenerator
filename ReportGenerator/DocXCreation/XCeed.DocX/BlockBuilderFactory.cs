using ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders;
using ReportGenerator.Model;
using System;

namespace ReportGenerator.DocXCreation.XCeed
{
	internal class BlockBuilderFactory : IBlockBuilderFactory
	{
		private readonly IBlockBuilder _testCaseBlockBuilder = new XCeedTestCaseBlockBuilder();
		private readonly IBlockBuilder _testSuiteBlockBuilder = new XCeedTestSuiteBlockBuilder();

		public IBlockBuilder GetBlockBuilder(IReportItem reportItem)
		{
			if(reportItem is TestCase)
			{
				return _testCaseBlockBuilder;
			}

			if(reportItem is TestSuite)
			{
				return _testSuiteBlockBuilder;
			}

			//remove
			if(reportItem is TestPlan)
			{
				return _testSuiteBlockBuilder;
			}

			throw new Exception("Unknown type of IReportItem");
		}
	}
}