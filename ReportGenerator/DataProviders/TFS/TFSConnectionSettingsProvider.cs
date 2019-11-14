using ReportGenerator.Settings;

namespace ReportGenerator
{
	internal class TFSConnectionSettingsProvider : IConnectionSettingsProvider
	{
		public IConnectionSettings Get(string url, string projectName)
		{
			return new TFSSettings(new System.Uri(url), projectName);
		}
	}
}