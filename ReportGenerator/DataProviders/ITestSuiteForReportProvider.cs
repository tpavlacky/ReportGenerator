using ProtocolGenerator;
using System;
using System.Threading;

namespace ReportGenerator
{
	public interface ITestSuiteForReportProvider
	{
		TestSuiteForReport GetData(CancellationToken cancellationToken, IProgress<string> progress);
	}
}
