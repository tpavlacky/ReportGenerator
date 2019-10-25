using System.Collections.Generic;

namespace ReportGenerator
{
	internal interface IFileTemplatesLoader
	{
		IEnumerable<TemplateInfo> Load(string templatesFolderPath);
	}
}