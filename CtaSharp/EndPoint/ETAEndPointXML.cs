using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.Models;
using CtaSharp.Parameters;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace CtaSharp.EndPoint
{
    internal class ETAEndPointXML : IEndpoint<ETA, ETAParameters>
    {
        IXmlConverter<ETA> _converter { get; }
        IDataSource<ETA> _dataSource { get; }

        internal ETAEndPointXML(string APIKey, IXmlConverter<ETA> converter, IDataSource<ETA> dataSource)
        {
			if (converter == null || dataSource == null || string.IsNullOrEmpty(APIKey)) {
				throw new ArgumentNullException ();
			}

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
