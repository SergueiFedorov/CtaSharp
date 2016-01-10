using CtaSharp.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.DataSource
{
    internal class ETADataSource : DataSourceBase, IDataSource
    {
        const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttfollow.aspx";

        string _APIKey { get; }

        public ETADataSource(string APIKey)
            : base(EndpointAddress)
        {
            _APIKey = APIKey;
        }

        public string Execute()
        {
			var result = base.DownloadContent();
			_client.QueryString.Clear();
			return result;
        }
    }
}
