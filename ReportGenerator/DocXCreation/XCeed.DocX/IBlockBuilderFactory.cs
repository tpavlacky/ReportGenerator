using ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders;
using ReportGenerator.Model;
using Xceed.Document.NET;

namespace ReportGenerator.DocXCreation.XCeed
{
	internal interface IBlockBuilderFactory
	{
		BlockBuilder GetBlockBuilder(Document document, IReportItem reportItem);
	}
}