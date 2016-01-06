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
        internal ETAEndPointXML(string APIKey)
            : base(APIKey, "http://lapi.transitchicago.com/api/1.0/ttfollow.aspx")
        {

        }

        public IEnumerable<ETA> Get(ETAParameters parameters)
        {
            base.ClearParameters();
            base.AddParameter("runnumber", parameters.RunNumber.ToString());

            var data = base.DownloadContent();

            //Todo: dependecy injection
            IXmlConverter<ETA> converter = new XMLToETAConverter();
            IEnumerable<ETA> result =  converter.Convert(data, "eta");

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
