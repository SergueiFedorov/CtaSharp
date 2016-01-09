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

        public void AddParameter(string name, string value)
        {
            _client.QueryString.Add(name, value);
        }

        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
