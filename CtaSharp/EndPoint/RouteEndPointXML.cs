﻿using CtaSharp.Models;
using CtaSharp.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint
{
    internal class LocationEndPointXML : IEndpoint<Route, RouteParameters>
    {
        IXmlConverter<Train> _TrainConverter { get; }
        IDataSource _RouteDataSource { get; set; }

        internal LocationEndPointXML(string APIKey)
        {
			
			_RouteDataSource = new RouteDataSource(APIKey);
            _TrainConverter = new XMLToTrainConverter();
        }

        internal LocationEndPointXML(string APIKey, IXmlConverter<Train> trainConverter)
        {
			if (trainConverter == null || string.IsNullOrEmpty(APIKey)) {
				throw new ArgumentNullException ();
			}

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
            string routeName = GetTrainRouteString(parameters.Route);
			_RouteDataSource.AddParameter("rt", routeName);

			var data = _RouteDataSource.Execute();
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
