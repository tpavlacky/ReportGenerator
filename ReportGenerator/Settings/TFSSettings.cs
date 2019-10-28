using System;

namespace ReportGenerator
{
	internal class TFSSettings : IConnectionSettings
	{
		public Uri Uri { get; }

		public string ProjectName { get; }

		public TFSSettings(Uri uri, string projectName)
		{
			Uri = uri;
			ProjectName = projectName;
		}
	}
}