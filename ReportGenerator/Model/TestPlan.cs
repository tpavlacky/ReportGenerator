using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public class TestPlan : ReportItem
	{
		public TestPlan(int id, int parentID, string caption, Uri url) 
			: base(id, parentID, caption, string.Empty, null, string.Empty, null, url)
		{
		}

		public TestPlan(int id, int parentID, string caption, IList<IReportItem> children, Uri url)
	: base(id, parentID, caption, string.Empty, null, string.Empty, null, children, url)
		{
		}
	}
}
