using System;

namespace ReportGenerator.Settings
{
	internal interface IConnectionSettings
	{
		Uri Uri { get; }

		string ProjectName { get; }
	}
}