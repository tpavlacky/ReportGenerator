using ReportGenerator.Model;
using System;
using System.Threading;

namespace ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders
{
	internal interface IBlockBuilder
	{
		void Build(Xceed.Document.NET.Document doc, IReportItem reportItem, uint level, CancellationToken cancellationToken, IProgress<string> progress);
	}
}
