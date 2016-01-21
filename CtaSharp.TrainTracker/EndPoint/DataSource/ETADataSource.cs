using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.DataSource
{
    internal class ETADataSource : DataSourceBase, IDataSource
    {
        const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttfollow.aspx";

        public ETADataSource()
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
