using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public class TestCase : ReportItem
	{
		//TODO -> should be on separate TestRunResult object
		public string Configuration { get; }
		public TimeSpan Duration { get; }
		public Uri TestRunResultUri { get; }

		public TestCase(int ID, int parentID, string caption, string summary)
			: this(ID, parentID, caption, summary, Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.NotExecuted, string.Empty, null, testCaseUri: null, testRunResultUri: null, configuration: string.Empty, duration: TimeSpan.FromSeconds(0))
		{
		}

		public TestCase(int ID, int parentID, string caption, string summary, TestOutcome outcome, string testedBy, DateTime? testedDate, Uri testCaseUri, Uri testRunResultUri, string configuration, TimeSpan duration) 
			: base(ID, parentID, caption, summary, outcome, testedBy, testedDate, testCaseUri)
		{
			Configuration = configuration;
			Duration = duration;
			TestRunResultUri = testRunResultUri;
		}

		public TestCase(int ID, int parentID, string caption, string summary, TestOutcome outcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url, string configuration, TimeSpan duration)
	: base(ID, parentID, caption, summary, outcome, testedBy, testedDate, children, url)
		{
			Configuration = configuration;
			Duration = duration;
		}
	}
}
