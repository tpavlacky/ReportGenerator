using System.Threading;

namespace ReportGenerator
{
	internal class DummyConnectionProvider : IConnectionProvider
	{
		public bool Test(IConnectionSettings connectionSettings)
		{
			Thread.Sleep(3500);
			return true;
		}
	}

}