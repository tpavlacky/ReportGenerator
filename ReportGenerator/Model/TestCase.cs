using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public class TestCase : ReportItem
	{
		public string Configuration { get; }
		public TimeSpan Duration { get; }

		public TestCase(int id, int parentID, string caption, string summary, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url, string configuration, TimeSpan duration) : base(id, parentID, caption, summary, testOutcome, testedBy, testedDate, children, url)
		{
			Configuration = configuration;
			Duration = duration;
		}
	}
}
