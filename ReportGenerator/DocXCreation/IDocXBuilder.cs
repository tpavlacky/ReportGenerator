using System;
using System.IO;
using System.Threading;

namespace ReportGenerator.DocXCreation
{
    internal interface IDocXBuilder
    {
        FileInfo CreateDocument(FileInfo docTemplate, CancellationToken cancellationToken, IProgress<string> progress);
    }
}