namespace ReportGenerator
{
	internal class TFSConnectionProvider : IConnectionProvider
	{
		public bool Test(IConnectionSettings connectionSettings)
		{
			return true;
		}
	}

}