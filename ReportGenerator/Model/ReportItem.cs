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

		public IList<IReportItem> Children { get; } = new List<IReportItem>();

		public Uri URI { get; }

		public string Summary { get; }

		protected ReportItem(int id, int parentID, string caption, string summary, TestOutcome? testOutcome, string testedBy, DateTime? testedDate, Uri url)
		{
			ID = id;
			ParentID = parentID;
			Caption = caption;
			Summary = summary;
			TestOutcome = testOutcome;
			TestedBy = testedBy;
			TestedDate = testedDate;
			URI = url;
		}

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
}
