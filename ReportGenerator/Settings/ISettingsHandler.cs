namespace ReportGenerator.Settings
{
	internal interface ISettingsHandler
	{
		IAppSettings Load();
		void Save(IAppSettings settings);
	}
}