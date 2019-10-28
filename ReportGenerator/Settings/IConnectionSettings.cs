using System;

namespace ReportGenerator
{
	internal interface IConnectionSettings
	{
		Uri Uri { get; }

		string ProjectName { get; }
	}
}