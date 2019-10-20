using System;
using System.Threading;

namespace ReportGenerator
{
	public interface ITestSuiteForReportProvider
	{
		TestSuiteForReport GetData(uint testSuiteID, CancellationToken cancellationToken, IProgress<string> progress);
	}
}
