using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using ReportGenerator.Model;
using XC = Xceed.Words.NET;

namespace ReportGenerator.DocXCreation.XCeed
{
	internal class XCeedDocXBuilder : IDocXBuilder
	{
		private readonly DefaultTemplateLoader _defaultTemplateLoader = new DefaultTemplateLoader();
		private readonly string _finalDocumentPath = Path.GetTempPath() + Path.GetRandomFileName() + ".docx";
		private readonly IBlockBuilderFactory _blockBuilderFactory = new BlockBuilderFactory();

		public FileInfo CreateDocument(FileInfo template, IEnumerable<IReportItem> reportItems, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var templateFullPath = GetDocTemplate(template).FullName;
			File.Copy(templateFullPath, _finalDocumentPath, true);

			using (var doc = XC.DocX.Load(_finalDocumentPath))
			{
				foreach (var reportItem in reportItems)
				{
					cancellationToken.ThrowIfCancellationRequested();
					//progress
					var hierarchyLevel = reportItem is TestPlan ? 0 : 1;
					GenerateReportItem(doc, reportItem, hierarchyLevel, cancellationToken, progress);
				}
				doc.Save();
			}

			return new FileInfo(_finalDocumentPath);
		}

		private void GenerateReportItem(XC.DocX doc, IReportItem reportItem, int level, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var blockBuilder = _blockBuilderFactory.GetBlockBuilder(doc, reportItem);
			blockBuilder.Build(reportItem, level, cancellationToken, progress);

			var testCases = reportItem.Children.OfType<TestCase>();
			foreach (var testCase in testCases)
			{
				GenerateReportItem(doc, testCase, level + 1, cancellationToken, progress);
			}

			var testSuites = reportItem.Children.OfType<TestSuite>();
			foreach (var testSuite in testSuites)
			{
				GenerateReportItem(doc, testSuite, level + 1, cancellationToken, progress);
			}
		}

		private FileInfo GetDocTemplate(FileInfo providedTemplate)
		{
			return (providedTemplate == null || !File.Exists(providedTemplate.FullName)) ? _defaultTemplateLoader.GetDefaultDocxTemplateFileInfo() : providedTemplate;
		}

		private void ProgressReport(IProgress<string> progress, string message)
		{
			progress?.Report(message);
		}
	}
}
