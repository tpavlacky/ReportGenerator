using System;
using System.IO;

namespace ReportGenerator.DocXCreation
{
	internal class DefaultTemplateLoader
	{
		public FileInfo GetDefaultDocxTemplateFileInfo()
		{
			var tempFileFullPath = Path.GetTempPath() + "Template_empty.docx";
			try
			{
				File.Delete(tempFileFullPath);
			}
			catch (UnauthorizedAccessException)
			{
				throw new Exception($"No access rights to path: {tempFileFullPath}");
			}
			catch (Exception) { }

			UnpackTemplate(tempFileFullPath);

			if (!File.Exists(tempFileFullPath))
			{
				throw new FileNotFoundException("Default template was not found");
			}

			return new FileInfo(tempFileFullPath);
		}

		private static void UnpackTemplate(string tempFileFullPath)
		{
			using (var ms = new MemoryStream(Properties.Resources.Template_empty))
			{
				using (var fs = new FileStream(tempFileFullPath, FileMode.CreateNew))
				{
					ms.CopyTo(fs);
				}
			}
		}

		private void SaveStreamToFile(string fileFullPath, Stream stream)
		{
			if (stream.Length == 0) return;

			using (FileStream fileStream = File.Create(fileFullPath, (int)stream.Length))
			{
				byte[] bytesInStream = new byte[stream.Length];
				stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

				fileStream.Write(bytesInStream, 0, bytesInStream.Length);
			}
		}

	}
}
