using CtaSharp.EndPoint.XML;
using CtaSharp.EndPoint.XML.Converters;
using CtaSharp.Models;
using CtaSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CtaSharp.EndPoint.Base.XML
{
    class ETAEndPointXML : BaseEndPointXML, IEndpoint<ETA, ETAParameters>
    {
        //Todo: allow this to be passed externally
        const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttfollow.aspx";
        IXmlConverter<ETA> _converter { get; }

        internal ETAEndPointXML(string APIKey, IXmlConverter<ETA> converter)
            : base(APIKey, EndpointAddress)
        {
            _converter = converter;
        }

        internal ETAEndPointXML(string APIKey)
            : base(APIKey, EndpointAddress)
        {
            _converter = new XMLToETAConverter();
        }

        public IEnumerable<ETA> Get(ETAParameters parameters)
        {
            base.ClearParameters();
            base.AddParameter("runnumber", parameters.RunNumber.ToString());

            var data = base.DownloadContent();
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
