using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportGenerator
{
	internal class DocXFileTemplatesLoader : IFileTemplatesLoader
	{
		public IEnumerable<TemplateInfo> Load(string templatesFolderPath)
		{
				if (string.IsNullOrEmpty(templatesFolderPath) || !Directory.Exists(templatesFolderPath))
				{
					return Enumerable.Empty<TemplateInfo>();
				}

				return Directory.GetFiles(templatesFolderPath, "*.docx")
					.Select(fullName =>
					{
						var fi = new FileInfo(fullName);
						return new TemplateInfo(fi.Name, fi.FullName);
					})
					.OrderBy(ti => ti.Name);
			}
	}
}