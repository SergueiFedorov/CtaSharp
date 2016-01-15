using CtaSharp.EndPoint;
using CtaSharp.Models;
using CtaSharp.Parameters;
using System.Collections.Generic;
using System.Linq;
using CtaSharp.Enums;
using System;

namespace CtaSharp
{
    public class CtaTrainTracker
    {
		private IEndpoint<Route, RouteParameters> _routeEnpoint { get; }
		private IEndpoint<ETA, ETAParameters> _etaEndpoint { get; }
		private IEndpoint<ETA, ArrivalsParameters> _arrivalsEnpoint { get; }

        public CtaTrainTracker(string APIKey)
			: this(new RouteEndPoint (APIKey), new ETAEndPoint (APIKey), new ArrivalsEndpoint (APIKey))
        {
			
        }

		internal CtaTrainTracker(
			IEndpoint<Route, RouteParameters> routeEnpoint, 
			IEndpoint<ETA, ETAParameters> etaEndpoint,
			IEndpoint<ETA, ArrivalsParameters> arrivalsEnpoint)
		{
			if (routeEnpoint == null || etaEndpoint == null || arrivalsEnpoint == null) {
				throw new ArgumentNullException ("All endpoints must be provided");
			}

			this._routeEnpoint = routeEnpoint;
			this._etaEndpoint = etaEndpoint;
			this._arrivalsEnpoint = arrivalsEnpoint;
		}

        public Route GetRoute(EnumTrainRoute route)
        {
            var parameters = new RouteParameters()
            {
                Route = route
            };

			return _routeEnpoint.Get(parameters).FirstOrDefault();
        }
        
        public IEnumerable<ETA> GetArrivalTimesByRunNumber(int runNumber)
        {
            var parameters = new ETAParameters()
            {
                RunNumber = runNumber
            };

			return _etaEndpoint.Get(parameters);
        }

        public IEnumerable<ETA> GetArrivalTimeByStopID(int stopID)
        {
            var parameters = new ArrivalsParameters()
            {
                NumericStopIdentifier = stopID
            };

			return _arrivalsEnpoint.Get(parameters);
        }

    }
}
