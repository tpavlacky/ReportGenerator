namespace ReportGenerator.Settings
{
	internal interface IAppSettings
	{
		string TemplateFullName { get; }
		string TFSAddress { get; }
		string ProjectName { get; }
	}
}