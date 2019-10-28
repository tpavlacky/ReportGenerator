namespace ReportGenerator
{
	internal interface IConnectionProvider
	{
		bool Test(IConnectionSettings connectionSettings);
	}
}