using System;

namespace ReportGenerator.Model
{
	public interface IProjectSettings
	{
		Uri URL { get; }

		string ProjectName { get; }

		string ID { get; }
	}
}
