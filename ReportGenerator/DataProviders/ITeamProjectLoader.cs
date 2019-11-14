using Microsoft.TeamFoundation.TestManagement.Client;
using ReportGenerator.Settings;

namespace ReportGenerator
{
	internal interface ITeamProjectLoader
	{
		ITestManagementTeamProject Load(IConnectionSettings connectionSettings);
	}
}
