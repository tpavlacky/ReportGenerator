﻿namespace ReportGenerator.DataProviders.TFS
{
	internal interface IUriFactoryProvider
	{
		IUriFactory GetFactory(IConnectionSettings connectionSettings);
	}
}
