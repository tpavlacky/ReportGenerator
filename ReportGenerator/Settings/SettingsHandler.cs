namespace ReportGenerator.Settings
{
	internal class SettingsHandler : ISettingsHandler
	{
		private readonly Properties.Settings _settings;

		public SettingsHandler()
		{
			_settings = Properties.Settings.Default;
		}

		public IAppSettings Load()
		{
			var templateSettings = new TemplateSettings
			{
				TemplateFullName = _settings.SelectedTemplate
			};
		
			return templateSettings;
		}

		public void Save(IAppSettings settings)
		{
			_settings.SelectedTemplate = settings.TemplateFullName;
			_settings.TFSAddress = settings.TFSAddress;
			_settings.ProjectName = settings.ProjectName;
			_settings.Save();
		}
	}
}