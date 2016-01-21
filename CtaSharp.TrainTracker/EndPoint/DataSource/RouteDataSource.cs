using System.Runtime.CompilerServices;
using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.DataSource
{
    internal class RouteDataSource : DataSourceBase, IDataSource
    {
        const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttpositions.aspx";

		public RouteDataSource()
            : base(EndpointAddress)
        {
			
        }

        public string Execute()
        {
			var result = base.DownloadContent();
			_client.QueryString.Clear();
			return result;
        }
    }
}
