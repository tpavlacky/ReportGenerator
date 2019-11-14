using ReportGenerator.Settings;

namespace ReportGenerator
{
	internal interface IConnectionSettingsProvider
	{
		IConnectionSettings Get(string url, string projectName);
	}
}