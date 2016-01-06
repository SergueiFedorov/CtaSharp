using CtaSharp.EndPoint;
using CtaSharp.Models;
using CtaSharp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CtaSharp.Tools.XML;
using CtaSharp.EndPoint.XML.Converters;
using CtaSharp.EndPoint.XML;

namespace CtaSharp
{
    class LocationEndPointXML : BaseEndPointXML, IEndpoint<Route, RouteParameters>
    {
        internal LocationEndPointXML(string APIKey)
            : base(APIKey, "http://lapi.transitchicago.com/api/1.0/ttpositions.aspx")
        {

        }

        public IEnumerable<Route> Get(RouteParameters parameters)
        {
            base._client.QueryString.Clear();
            base._client.QueryString.Add("key", this.APIKey);
            string routeName = "";

            switch(parameters.Route)
            {
                case TrainRoute.Red:
                    {
                        routeName = "Red";
                        break;
                    }
                default:
                    {
                        throw new Exception("Cannot determine train route");
                    }
            }

            base._client.QueryString.Add("rt", routeName);

            var data = base._client.DownloadString(uri);

            IXmlConverter<Train> trainConverter = new XMLToTrainConverter();
            var trains = trainConverter.Convert(data, "train");

            return new Route[]
            {
                new Route() { Trains = trains }
            };
        }

        public async Task<IEnumerable<Route>> GetAsync(RouteParameters parameters)
        {
            return await Task.Run(() =>
            {
                return this.Get(parameters);
            });
        }
    }
}
