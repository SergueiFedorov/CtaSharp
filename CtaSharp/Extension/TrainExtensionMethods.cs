using CtaSharp.EndPoint;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.Models;
using CtaSharp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.Extension
{
    public static class TrainExtensionMethods
    {
        public static void Refresh(this Train train)
        {
            IEndpoint<Route, RouteParameters> endpoint = train.Route.EndPoint;
            var result = endpoint.Get(new RouteParameters() { Route = train.Route.TrainRoute });

            var updatedTrain = result.SelectMany(x => x.Trains).SingleOrDefault(x => x.RunNumber == train.RunNumber);
            train.DestinationName = updatedTrain.DestinationName;
            train.DestinationStopNumber = updatedTrain.DestinationStopNumber;
            train.Flags = updatedTrain.Flags;
            train.HeadingDegrees = updatedTrain.HeadingDegrees;
            train.IsApproaching = updatedTrain.IsApproaching;
            train.IsDelayed = updatedTrain.IsDelayed;
            train.NextStationID = updatedTrain.NextStationID;
            train.NextStationName = updatedTrain.NextStationName;
            train.NextStopID = updatedTrain.NextStopID;
            train.PredicatedArrival = updatedTrain.PredicatedArrival;
            train.PredicationGeneratedTime = updatedTrain.PredicationGeneratedTime;
            train.Route = updatedTrain.Route;
            train.TrainDirection = updatedTrain.TrainDirection;
            train.TrainLatitude = updatedTrain.TrainLatitude;
            train.TrainLongitude = updatedTrain.TrainLongitude;
        }
    }
}
