using System;
using CtaSharp.Models;

namespace CtaSharp.EndPoint.XML.DataSource
{
    class TrainDataSource : DataSourceBase, IDataSource<Train>
    {
        const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttpositions.aspx";

        public TrainDataSource(string APIKey)
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
