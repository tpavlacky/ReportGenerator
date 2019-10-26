using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ReportGenerator.DocXCreation
{
    internal interface IDocXBuilder
    {
        FileInfo CreateDocument(FileInfo template, IEnumerable<IReportItem> reportItems, CancellationToken cancellationToken, IProgress<string> progress);
    }
}