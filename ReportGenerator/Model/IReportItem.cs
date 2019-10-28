using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public interface IReportItem
	{
		int ID { get; }

		int ParentID { get; }

		string Caption { get; }

		string Summary { get; }

		Uri URI { get; }

		TestOutcome? TestOutcome { get; }
		
		string TestedBy { get; }

		DateTime? TestedDate { get; }

		IList<IReportItem> Children { get; }
	}
}
