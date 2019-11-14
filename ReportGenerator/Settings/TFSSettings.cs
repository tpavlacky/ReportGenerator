using System;

namespace ReportGenerator.Settings
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