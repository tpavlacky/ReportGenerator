namespace ReportGenerator.DataProviders.TFS
{
	internal class TFSUriFactoryProvider : IUriFactoryProvider
	{
		public IUriFactory GetFactory(IConnectionSettings connectionSettings)
		{
			return new TFSItemUriFactory(connectionSettings);
		}
	}
}
