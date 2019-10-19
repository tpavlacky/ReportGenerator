using ProtocolGenerator;
using ProtocolGenerator.DocXCreation;

namespace ReportGenerator
{
    internal interface IDocXBuilderFactory
    {
        IDocXBuilder GetDocXBuilder(DocXBuilderType builderType, TestSuiteForReport testSuiteForReport);
    }
}