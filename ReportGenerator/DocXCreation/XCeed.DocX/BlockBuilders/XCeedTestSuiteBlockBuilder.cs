using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ReportGenerator.Model;
using Xceed.Document.NET;

namespace ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders
{
	internal class XCeedTestSuiteBlockBuilder : IBlockBuilder
	{
		public void Build(Document doc, IReportItem reportItem, uint level, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var par = doc.InsertParagraph(new string(' ', (int)level * 3) + "Level: " + level + reportItem.Caption).Font(new Font("Segoe UI")).FontSize(12);
		}
	}
}
