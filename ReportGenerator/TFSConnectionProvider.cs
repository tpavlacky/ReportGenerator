using System.Threading;

namespace ReportGenerator
{
	internal class TFSConnectionProvider : IConnectionProvider
	{
		public bool Test(IConnectionSettings connectionSettings)
		{
			return true;
		}
	}

	internal class DummyConnectionProvider : IConnectionProvider
	{
		public bool Test(IConnectionSettings connectionSettings)
		{
			Thread.Sleep(3500);
			return true;
		}
	}

}