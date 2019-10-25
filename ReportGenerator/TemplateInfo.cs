namespace ReportGenerator
{
	public class TemplateInfo
	{
		public string Name { get; }

		public string FullName { get; }

		public TemplateInfo(string name, string fullName)
		{
			Name = name;
			FullName = fullName;
		}
	}
}