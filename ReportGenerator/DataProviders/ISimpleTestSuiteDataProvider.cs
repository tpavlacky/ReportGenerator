using System;
using System.Threading;

namespace ReportGenerator
{
	public interface ISimpleTestSuiteDataProvider
	{
		TestSuiteForReport GetData(uint testSuiteID, CancellationToken cancellationToken, IProgress<string> progress);
	}
}
