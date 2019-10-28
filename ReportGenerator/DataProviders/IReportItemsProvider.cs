using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ReportGenerator
{
	public interface IReportItemsProvider
	{
		IList<IReportItem> GetData(uint testPlanID, CancellationToken cancellationToken, IProgress<string> progress);
	}
}
