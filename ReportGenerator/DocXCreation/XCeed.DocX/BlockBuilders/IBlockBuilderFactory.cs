using ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders;
using ReportGenerator.Model;

namespace ReportGenerator.DocXCreation.XCeed
{
	internal interface IBlockBuilderFactory
	{
		IBlockBuilder GetBlockBuilder(IReportItem reportItem);
	}
}