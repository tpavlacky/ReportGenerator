using Microsoft.TeamFoundation.TestManagement.Client;

namespace ReportGenerator
{
	internal interface ITeamProjectLoader
	{
		ITestManagementTeamProject Load(IConnectionSettings connectionSettings);
	}
}
