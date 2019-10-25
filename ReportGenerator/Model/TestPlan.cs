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

		public Uri URL { get; }

		protected ReportItem(int id, int parentID, string caption, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url)
		{
			ID = id;
			ParentID = parentID;
			Caption = caption;
			TestOutcome = testOutcome;
			TestedBy = testedBy;
			TestedDate = testedDate;
			Children = children;
			URL = url;
		}
	}

	public class TestPlan : ReportItem
	{
		public TestPlan(int id, int parentID, string caption, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url) : base(id, parentID, caption, testOutcome, testedBy, testedDate, children, url)
		{
		}
	}

	public class TestSuite : ReportItem
	{
		public TestSuite(int id, int parentID, string caption, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url) : base(id, parentID, caption, testOutcome, testedBy, testedDate, children, url)
		{
		}
	}

	public class TestCase : ReportItem
	{
		public TestCase(int id, int parentID, string caption, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, IList<IReportItem> children, Uri url) : base(id, parentID, caption, testOutcome, testedBy, testedDate, children, url)
		{
		}
	}

	public interface IReportItem
	{
		int ID { get; }

		int ParentID { get; }

		string Caption { get; }

		Uri URL { get; }

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
