using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders
{
	internal interface IBlockBuilder
	{
		void Build(Xceed.Document.NET.Document doc, IReportItem reportItem, uint level, CancellationToken cancellationToken, IProgress<string> progress);
	}
}
