using System;
using CtaSharp.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.DataSource
{
    internal class RouteDataSource : DataSourceBase, IDataSource
    {
        const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttpositions.aspx";

		public RouteDataSource(string APIKey)
            : base(EndpointAddress)
        {

        }

        public string Execute()
        {
			_client.QueryString.Clear();
			return base.DownloadContent();
        }
    }
}
