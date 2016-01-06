using CtaSharp.EndPoint.Base.XML;
using CtaSharp.Models;
using CtaSharp.Parameters;
using System.Collections.Generic;
using System.Linq;

namespace CtaSharp
{
    public class CtaTrainTracker
    {
        private string _APIKey { get; }

        public CtaTrainTracker(string APIKey)
        {
            this._APIKey = APIKey;
        }

        public Route GetRoute(EnumTrainRoute route)
        {
            IEndpoint<Route, RouteParameters> endpoint = new LocationEndPointXML(this._APIKey);
            RouteParameters parameters = new RouteParameters()
            {
                Route = route
            };

            return endpoint.Get(parameters).FirstOrDefault();
        }
        
        public IEnumerable<ETA> GetArrivalTimesByRunNumber(int runNumber)
        {
            IEndpoint<ETA, ETAParameters> endpoint = new ETAEndPointXML(this._APIKey);
            ETAParameters parameters = new ETAParameters()
            {
                RunNumber = runNumber
            };

            return endpoint.Get(parameters);
        }
    }
}
