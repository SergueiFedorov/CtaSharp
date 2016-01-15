using System;

namespace CtaSharp.EndPoint.DataSource
{
	internal class ArrivalsDataSource : DataSourceBase, IDataSource
	{
		const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttarrivals.aspx";

		internal ArrivalsDataSource()
			: base(EndpointAddress)
		{
			
		}

		public string Execute()
		{
			return base.DownloadContent ();
		}
	}
}

