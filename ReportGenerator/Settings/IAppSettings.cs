namespace ReportGenerator
{
	internal interface IAppSettings
	{
		string TemplateFullName { get; }
		string TFSAddress { get; }
		string ProjectName { get; }
	}
}