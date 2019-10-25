using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ReportGenerator
{
	public interface ITestSuiteForReportProvider
	{
		TestSuiteForReport GetData(uint testSuiteID, CancellationToken cancellationToken, IProgress<string> progress);
	}

	public interface ITestPlanForReportProvider
	{
		IList<IReportItem> GetData(uint testPlanID, CancellationToken cancellationToken, IProgress<string> progress);
	}
}
