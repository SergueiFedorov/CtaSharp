using CtaSharp.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.DataSource
{
    internal class ETADataSource : DataSourceBase, IDataSource<ETA>
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
            _client.QueryString.Clear();
            return base.DownloadContent();
        }

        public void AddParameter(string name, string value)
        {
            _client.QueryString.Add(name, value);
        }
    }
}
