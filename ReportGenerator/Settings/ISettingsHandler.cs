namespace ReportGenerator
{
	internal interface ISettingsHandler
	{
		IAppSettings Load();
		void Save(IAppSettings settings);
	}
}