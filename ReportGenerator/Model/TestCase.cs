using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public class TestCase : ReportItem
	{
		public string Configuration { get; }
		public TimeSpan Duration { get; }

		public TestCase(int ID, int parentID, string caption, string summary)
			: this(ID, parentID, caption, summary, Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.NotExecuted, string.Empty, null, null, string.Empty, TimeSpan.FromSeconds(0))
		{
		}

		public TestCase(int ID, int parentID, string caption, string summary, TestOutcome outcome, string testedBy, DateTime? testedDate, Uri url, string configuration, TimeSpan duration) 
			: base(ID, parentID, caption, summary, outcome, testedBy, testedDate, url)
		{
			Configuration = configuration;
			Duration = duration;
		}

		public TestCase(int ID, int parentID, string caption, string summary, TestOutcome outcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url, string configuration, TimeSpan duration)
	: base(ID, parentID, caption, summary, outcome, testedBy, testedDate, children, url)
		{
			Configuration = configuration;
			Duration = duration;
		}
	}
}
