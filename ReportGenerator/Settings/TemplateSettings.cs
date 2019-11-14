namespace ReportGenerator.Settings
{
	internal struct TemplateSettings : IAppSettings
	{
		public string TemplateFullName { get; set; }

		public string TFSAddress { get; set; }

		public string ProjectName { get; set; }
	}
}