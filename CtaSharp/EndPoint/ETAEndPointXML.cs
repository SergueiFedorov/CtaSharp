using CtaSharp.EndPoint.XML;
using CtaSharp.EndPoint.XML.Converters;
using CtaSharp.EndPoint.XML.DataSource;
using CtaSharp.Models;
using CtaSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CtaSharp.EndPoint.Base.XML
{
    internal class ETAEndPointXML : IEndpoint<ETA, ETAParameters>
    {
        IXmlConverter<ETA> _converter { get; }
        IDataSource<ETA> _dataSource { get; }

        internal ETAEndPointXML(string APIKey, IXmlConverter<ETA> converter, IDataSource<ETA> dataSource)
        {
            _dataSource = dataSource;
            _converter = converter;
        }

        internal ETAEndPointXML(string APIKey)
        {
            _dataSource = new ETADataSource(APIKey);
            _converter = new XMLToETAConverter();
        }

        public IEnumerable<ETA> Get(ETAParameters parameters)
        {
            _dataSource.AddParameter("runnumber", parameters.RunNumber.ToString());

            var data = _dataSource.Execute();
            IEnumerable<ETA> result = _converter.Convert(data, "eta");

            return result;
        }

        public async Task<IEnumerable<ETA>> GetAsync(ETAParameters parameters)
        {
            return await Task.Run(() =>
            {
                return this.Get(parameters);
            });
        }
    }
}
