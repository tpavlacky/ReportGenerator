using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public class TestPlan : ReportItem
	{
		public TestPlan(int id, int parentID, string caption, string summary, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url) : base(id, parentID, caption, summary, testOutcome, testedBy, testedDate, children, url)
		{
		}
	}
}
