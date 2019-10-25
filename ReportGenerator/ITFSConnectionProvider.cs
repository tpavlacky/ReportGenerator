using System;

namespace ReportGenerator
{
	internal interface IConnectionProvider
	{
		bool Test(IConnectionSettings connectionSettings);
	}

	internal interface IConnectionSettings
	{
		Uri Uri { get; }

		string ProjectName { get; }
	}

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