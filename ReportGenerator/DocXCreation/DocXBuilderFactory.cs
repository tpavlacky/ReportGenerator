using ReportGenerator;
using ReportGenerator.DocXCreation;
using ReportGenerator.DocXCreation.XCeed;

namespace ReportGenerator
{
	internal class DocXBuilderFactory : IDocXBuilderFactory
	{
		public IDocXBuilder GetDocXBuilder(DocXBuilderType builderType)
		{
			switch (builderType)
			{
				case DocXBuilderType.FreeSpire:
					//return new SpireDocXBuilder(testSuiteForReport, new SpireDocFontStyles());
					return new SpireDocXBuilder();
				case DocXBuilderType.DocX:
					return new XCeedDocXBuilder();
			}

			return null;
		}
	}
}