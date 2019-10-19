using System;
using System.IO;
using System.Threading;

namespace ProtocolGenerator.DocXCreation
{
    internal interface IDocXBuilder
    {
        FileInfo CreateDocument(CancellationToken cancellationToken, IProgress<string> progress);
    }
}