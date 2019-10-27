using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
	public abstract class ReportItem : IReportItem
	{
		public int ID { get; }

		public int ParentID { get; }

		public string Caption { get; }

		public TestOutcome? TestOutcome { get; }

		public string TestedBy { get; }

		public DateTime? TestedDate { get; }

		public IList<IReportItem> Children { get; }

		public Uri URI { get; }

		public string Summary { get; }

		protected ReportItem(int id, int parentID, string caption, string summary, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url)
		{
			ID = id;
			ParentID = parentID;
			Caption = caption;
			Summary = summary;
			TestOutcome = testOutcome;
			TestedBy = testedBy;
			TestedDate = testedDate;
			Children = children;
			URI = url;
		}
	}

	public class TestPlan : ReportItem
	{
		public TestPlan(int id, int parentID, string caption, string summary, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url) : base(id, parentID, caption, summary, testOutcome, testedBy, testedDate, children, url)
		{
		}
	}

	public class TestSuite : ReportItem
	{
		public TestSuite(int id, int parentID, string caption, string summary, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url) : base(id, parentID, caption, summary, testOutcome, testedBy, testedDate, children, url)
		{
		}
	}

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

	public interface IProjectSettings
	{
		Uri URL { get; }

		string ProjectName { get; }

		string ID { get; }
	}
}
