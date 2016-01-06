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

        private string GetTrainRouteString(EnumTrainRoute route)
        {
            switch (route)
            {
                case EnumTrainRoute.Red:
                    {
                        return "Red";
                    }
                case EnumTrainRoute.Blue:
                    {
                        return "Blue";
                    }
                case EnumTrainRoute.Brown:
                    {
                        return "Brn";
                    }
                case EnumTrainRoute.Purple:
                    {
                        return "P";
                    }
                case EnumTrainRoute.Green:
                    {
                        return "G";
                    }
                case EnumTrainRoute.Orange:
                    {
                        return "Org";
                    }
                case EnumTrainRoute.Pink:
                    {
                        return "Pink";
                    }
                case EnumTrainRoute.Yellow:
                    {
                        return "Y";
                    }
                default:
                    {
                        throw new Exception("Cannot determine train route");
                    }
            }
        }

        //Todo: Clean up
        public IEnumerable<Route> Get(RouteParameters parameters)
        {
            base.ClearParameters();

            string routeName = GetTrainRouteString(parameters.Route);
            AddParameter("rt", routeName);

            var data = base.DownloadContent();

            //Todo: dependecy injection
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
