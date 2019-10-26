using ReportGenerator;
using ReportGenerator.DocXCreation;

namespace ReportGenerator
{
    internal interface IDocXBuilderFactory
    {
        IDocXBuilder GetDocXBuilder(DocXBuilderType builderType);
    }
}