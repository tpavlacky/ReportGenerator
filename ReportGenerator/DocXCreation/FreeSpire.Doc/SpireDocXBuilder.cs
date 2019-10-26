using System;
using System.IO;
using ReportGenerator.Extenders;
using Spire.Doc;
using System.Threading;
using ReportGenerator.Model;
using System.Linq;
using System.Collections.Generic;

namespace ReportGenerator.DocXCreation
{
	internal class SpireDocXBuilder : IDocXBuilder
	{
		private readonly string _finalDocumentPath = Path.GetTempPath() + Path.GetRandomFileName() + ".docx";//Path.GetTempPath() + "Report.docx";
		private const int CHUNK_SIZE = 25;

		public FileInfo CreateDocument(FileInfo template, IEnumerable<IReportItem> rootReportItem, CancellationToken cancellationToken, IProgress<string> progress)
		{
			if (rootReportItem == null)
			{
				throw new ArgumentNullException(nameof(rootReportItem));
			}

			var templateFullPath = GetDocTemplate(template).FullName;
			File.Copy(templateFullPath, _finalDocumentPath, true);

			//var nestedLevel = 0;
			var doc = new Document(_finalDocumentPath);

			//GenerateFinalReport(doc, rootReportItem, nestedLevel, cancellationToken, progress);

			////free spiro is limited to 25 tables per section => after every 25 test cases needs to be new section
			//var testResultsChunks = reportItem.TestResults.Chunk(CHUNK_SIZE);

			//ProgressReport(progress, "Creating DocX file");
			//var doc = new Document(_finalDocumentPath);
			//var section = doc.LastSection ?? doc.AddSection();

			//ProgressReport(progress, "Generating test suite information");
			//var testSuiteHeaderBuilder = new TestSuiteBlockBuilder(section);
			//testSuiteHeaderBuilder.AppendTestSuiteInformation(reportItem);

			//var actualTestCase = 0;
			//foreach (var testResultsChunk in testResultsChunks)
			//{
			//	var testCaseBlockBuilder = new TestCaseBlockBuilder(section);
			//	foreach (var testResultForReport in testResultsChunk)
			//	{
			//		actualTestCase++;
			//		ProgressReport(progress, $"Generating test case {actualTestCase}/{reportItem.TestResults.Count} ...");
			//		testCaseBlockBuilder.Build(reportItem, testResultForReport);
			//		cancellationToken.ThrowIfCancellationRequested();
			//	}
			//	section = doc.AddSection();
			//}

			doc.SaveToFile(_finalDocumentPath);

			//if (docTemplate == null)
			//{
			//	ClearTempFiles(templateFullPath);
			//}

			return new FileInfo(_finalDocumentPath);
		}

		private void GenerateFinalReport(Document doc, IReportItem rootReportItem, int level, CancellationToken cancellationToken, IProgress<string> progress)
		{
			var testSuites = rootReportItem.Children.OfType<TestSuite>();
			var testCases = rootReportItem.Children.OfType<TestCase>();
			var section = doc.AddSection();
			foreach(var testSuite in testSuites)
			{

			}

			var testCasesChunks = testCases.Chunk(CHUNK_SIZE);
			foreach (var testCase in testCases)
			{
				var testCaseBlockBuilder = new TestCaseBlockBuilder(section);
			}
		}

		private FileInfo GetDocTemplate(FileInfo providedTemplate)
		{
			return (providedTemplate == null || !File.Exists(providedTemplate.FullName)) ? GetDefaultDocxTemplateFileInfo() : providedTemplate;
		}

		private void ProgressReport(IProgress<string> progress, string message)
		{
			progress?.Report(message);
		}

		private static void ClearTempFiles(string templatePath)
		{
			try
			{
				File.Delete(templatePath);
			}
			catch (Exception)
			{
			}
		}

		private FileInfo GetDefaultDocxTemplateFileInfo()
		{
			var tempFileFullPath = Path.GetTempPath() + "Template_empty.docx";
			try
			{
				File.Delete(tempFileFullPath);
			}
			catch (UnauthorizedAccessException)
			{
				throw new Exception($"No access rights to path: {tempFileFullPath}");
			}
			catch (Exception) { }

			UnpackTemplate(tempFileFullPath);

			if (!File.Exists(tempFileFullPath))
			{
				throw new FileNotFoundException("Default template was not found");
			}

			return new FileInfo(tempFileFullPath);
		}

		private static void UnpackTemplate(string tempFileFullPath)
		{
			using (var ms = new MemoryStream(Properties.Resources.Template_empty))
			{
				using (var fs = new FileStream(tempFileFullPath, FileMode.CreateNew))
				{
					ms.CopyTo(fs);
				}
			}
		}

		private void SaveStreamToFile(string fileFullPath, Stream stream)
		{
			if (stream.Length == 0) return;

			using (FileStream fileStream = File.Create(fileFullPath, (int)stream.Length))
			{
				byte[] bytesInStream = new byte[stream.Length];
				stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

				fileStream.Write(bytesInStream, 0, bytesInStream.Length);
			}
		}

		//private void InitStyles(Document doc)
		//{
		//	AddStyle(doc, _testReportStyles.Default);

		//	AddStyle(doc, _testReportStyles.TestSuiteHeader);
		//	AddStyle(doc, _testReportStyles.TestCaseHeader);
		//	AddStyle(doc, _testReportStyles.SummaryHeader);

		//	AddStyle(doc, _testReportStyles.FailedTestCase);
		//	AddStyle(doc, _testReportStyles.PassedTestCase);
		//}

		//private void AddStyle(Document doc, IDocStyle docStyle)
		//{
		//	var style = doc.AddParagraphStyle(docStyle.StyleName);

		//	style.CharacterFormat.FontName = docStyle.FontName;
		//	style.CharacterFormat.FontSize = docStyle.FontSize;
		//	style.CharacterFormat.TextColor = docStyle.FontColor;

		//	style.CharacterFormat.Bold = docStyle.Bold;
		//	style.CharacterFormat.Italic = docStyle.Italic;
		//}
	}
}
