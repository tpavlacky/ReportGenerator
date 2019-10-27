using ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders;
using ReportGenerator.Model;
using System;
using Xceed.Document.NET;

namespace ReportGenerator.DocXCreation.XCeed
{
	internal class BlockBuilderFactory : IBlockBuilderFactory
	{
		private BlockBuilder _testCaseBlockBuilder;
		private BlockBuilder _testSuiteBlockBuilder;

		public BlockBuilder GetBlockBuilder(Document document, IReportItem reportItem)
		{
			if(reportItem is TestCase)
			{
				return GetTestCaseBlockBuilder(document);
			}

			if(reportItem is TestSuite || reportItem is TestPlan)
			{
				return GetTestSuiteBlockBuilder(document);
			}

			throw new Exception("Unknown type of IReportItem");
		}

		private BlockBuilder GetTestCaseBlockBuilder(Document document)
		{
			if(_testCaseBlockBuilder == null)
			{
				_testCaseBlockBuilder = new XCeedTestCaseBlockBuilder(document);
			}

			return _testCaseBlockBuilder;
		}

		private BlockBuilder GetTestSuiteBlockBuilder(Document document)
		{
			if(_testSuiteBlockBuilder == null)
			{
				_testSuiteBlockBuilder = new XCeedTestSuiteBlockBuilder(document);
			}

			return _testSuiteBlockBuilder;
		}
	}
}