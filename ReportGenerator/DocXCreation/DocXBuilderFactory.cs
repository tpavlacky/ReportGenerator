using ProtocolGenerator;
using ProtocolGenerator.DocXCreation;

namespace ReportGenerator
{
	internal class DocXBuilderFactory : IDocXBuilderFactory
	{
		public IDocXBuilder GetDocXBuilder(DocXBuilderType builderType, TestSuiteForReport testSuiteForReport)
		{
			switch (builderType)
			{
				case DocXBuilderType.FreeSpire:
					//return new SpireDocXBuilder(testSuiteForReport, new SpireDocFontStyles());
					return new SpireDocXBuilder(testSuiteForReport);
				case DocXBuilderType.DocX:
					return null;
			}

			return null;
		}
	}
}