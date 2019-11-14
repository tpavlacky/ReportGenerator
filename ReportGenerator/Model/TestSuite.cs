using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public class TestSuite : ReportItem
	{
		public TestSuite(int id, int parentID, string caption, Uri url) 
			: base(id, parentID, caption, string.Empty, null, string.Empty, null, url)
		{
		}

		public TestSuite(int id, int parentID, string caption, IList<IReportItem> children, Uri url)
	: base(id, parentID, caption, string.Empty, null, string.Empty, null, children, url)
		{
		}
	}
}
