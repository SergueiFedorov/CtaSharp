using CtaSharp.Models;
using CtaSharp.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtaSharp.EndPoint.XML.Converters;
using CtaSharp.EndPoint.XML;

namespace CtaSharp
{
    class LocationEndPointXML : BaseEndPointXML, IEndpoint<Route, RouteParameters>
    {
        const string EndpointAddress = "http://lapi.transitchicago.com/api/1.0/ttpositions.aspx";
        IXmlConverter<Train> _TrainConverter { get; }

        internal LocationEndPointXML(string APIKey)
            : base(APIKey, EndpointAddress)
        {
            _TrainConverter = new XMLToTrainConverter();
        }

        internal LocationEndPointXML(string APIKey, IXmlConverter<Train> trainConverter)
             : base(APIKey, EndpointAddress)
        {
            _TrainConverter = trainConverter;
        }

        private string GetTrainRouteString(EnumTrainRoute route)
        {
            switch (route)
            {
                case EnumTrainRoute.Red:
                        return "Red";
                case EnumTrainRoute.Blue:
                        return "Blue";
                case EnumTrainRoute.Brown:
                        return "Brn";
                case EnumTrainRoute.Purple:
                        return "P";
                case EnumTrainRoute.Green:
                        return "G";
                case EnumTrainRoute.Orange:
                        return "Org";
                case EnumTrainRoute.Pink:
                        return "Pink";
                case EnumTrainRoute.Yellow:
                        return "Y";
                default:
                        throw new Exception("Cannot determine train route");
            }
        }

        public IEnumerable<Route> Get(RouteParameters parameters)
        {
            base.ClearParameters();

            string routeName = GetTrainRouteString(parameters.Route);
            AddParameter("rt", routeName);

            var data = base.DownloadContent();
            var trains = _TrainConverter.Convert(data, "train");

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
