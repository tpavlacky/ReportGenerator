namespace ReportGenerator
{
	internal interface ISettingsHandler
	{
		IAppSettings Load();
		void Save(IAppSettings settings);
	}

	internal interface IAppSettings
	{
		string TemplateFullName { get; }
		string TFSAddress { get; }
		string ProjectName { get; }
	}

	internal struct TemplateSettings : IAppSettings
	{
		public string TemplateFullName { get; set; }

		public string TFSAddress { get; set; }

		public string ProjectName { get; set; }
	}
}