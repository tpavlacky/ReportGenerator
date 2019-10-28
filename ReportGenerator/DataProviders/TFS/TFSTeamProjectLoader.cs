using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;

namespace ReportGenerator
{
	internal class TFSTeamProjectLoader : ITeamProjectLoader
	{
		private readonly IProgress<string> _progress;

		public TFSTeamProjectLoader(IProgress<string> progress)
		{
			_progress = progress;
		}

		public ITestManagementTeamProject Load(IConnectionSettings connectionSettings)
		{
			var tfsCollection = InitializeTFSCollection(connectionSettings);
			var testManagementService = tfsCollection.GetService<ITestManagementService>();
			ReportProgress($"Loading project '{connectionSettings.ProjectName}' ...");
			var teamProject = testManagementService.GetTeamProject(connectionSettings.ProjectName);

			if (teamProject == null)
			{
				throw new Exception($"Cannot find project with name: '{connectionSettings.ProjectName}'");
			}

			return teamProject;
		}

		private TfsTeamProjectCollection InitializeTFSCollection(IConnectionSettings connectionSettings)
		{
			ReportProgress($"Connecting to {connectionSettings.Uri} ...");
			var tfsCollection = new TfsTeamProjectCollection(connectionSettings.Uri);
			tfsCollection.EnsureAuthenticated();
			return tfsCollection;
		}

		private void ReportProgress(string message)
		{
			_progress?.Report(message);
		}

	}
}
