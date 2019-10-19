using System;
using System.IO;
using ProtocolGenerator.Extenders;
using Spire.Doc;
using System.Threading;

namespace ProtocolGenerator.DocXCreation
{
	internal class SpireDocXBuilder : IDocXBuilder
	{
		private readonly string _finalDocumentPath = Path.GetTempPath() + "Report.docx";
		protected readonly TestSuiteForReport _testSuiteForReport;

		private const int CHUNK_SIZE = 25;

		public SpireDocXBuilder(TestSuiteForReport testSuiteForReport)
		{
			_testSuiteForReport = testSuiteForReport;
		}

		public FileInfo CreateDocument(CancellationToken cancellationToken, IProgress<string> progress)
		{
			if (_testSuiteForReport == null)
			{
				throw new ArgumentNullException(nameof(_testSuiteForReport));
			}

			var templatePath = GetDocxTemplatePath();
			File.Copy(templatePath, _finalDocumentPath, true);

			//free spiro is limited to 25 tables per section => after every 25 test cases needs to be new section
			var testResultsChunks = _testSuiteForReport.TestResults.Chunk(CHUNK_SIZE);

			ProgressReport(progress, "Creating DocX file");
			var doc = new Document(_finalDocumentPath);
			var section = doc.AddSection();

			ProgressReport(progress, "Generating test suite information");
			var testSuiteHeaderBuilder = new TestSuiteBlockBuilder(section);
			testSuiteHeaderBuilder.AppendTestSuiteInformation(_testSuiteForReport);

			var actualTestCase = 0;
			foreach (var testResultsChunk in testResultsChunks)
			{
				var testCaseBlockBuilder = new TestCaseBlockBuilder(section);
				foreach (var testResultForReport in testResultsChunk)
				{
					actualTestCase++;
					ProgressReport(progress, $"Generating test case {actualTestCase}/{_testSuiteForReport.TestResults.Count} ...");
					testCaseBlockBuilder.Build(_testSuiteForReport, testResultForReport);
					cancellationToken.ThrowIfCancellationRequested();
				}
				section = doc.AddSection();
			}

			doc.SaveToFile(_finalDocumentPath);

			ClearTempFiles(templatePath);

			return new FileInfo(_finalDocumentPath);
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

		private string GetDocxTemplatePath()
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

			return tempFileFullPath;
		}

		private static void UnpackTemplate(string tempFileFullPath)
		{
			using (var ms = new MemoryStream(ReportGenerator.Properties.Resources.Template_empty))
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
