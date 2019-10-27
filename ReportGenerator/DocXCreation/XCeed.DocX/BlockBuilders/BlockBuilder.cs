using System;
using System.Threading;
using ReportGenerator.Model;
using Xceed.Document.NET;

namespace ReportGenerator.DocXCreation.XCeed.DocX.BlockBuilders
{
	internal abstract class BlockBuilder
	{
		protected readonly Document _document;

		public abstract void Build(IReportItem reportItem, uint level, CancellationToken cancellationToken, IProgress<string> progress);

		public BlockBuilder(Document document)
		{
			_document = document;
		}

		protected Hyperlink CreateHyperLink(string text, Uri uri)
		{
			return _document.AddHyperlink(text, uri);
		}
	}
}
