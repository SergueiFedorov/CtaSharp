using CtaSharp.Models;
using CtaSharp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp
{
    internal class TrainEndpointXML : IEndpoint<Train, TrainParameters>
    {
        IEndpoint<Route, RouteParameters> _routeEndpoint { get; }
        TrainRoute _route { get; }

        internal TrainEndpointXML(IEndpoint<Route, RouteParameters> routeEndpoint, TrainRoute route)
        {
            _routeEndpoint = routeEndpoint;
        }

        public IEnumerable<Train> Get(TrainParameters parameters)
        {
            RouteParameters routeParameters = new RouteParameters()
            {
                Route = this._route
            };

            var trainsOnRoute = _routeEndpoint.Get(routeParameters);
            return trainsOnRoute.First().Trains.Where(x => x.RunNumber == parameters.RunNumber);
        }

        public async Task<IEnumerable<Train>> GetAsync(TrainParameters parameters)
        {
            return await Task.Run(() =>
            {
                return this.Get(parameters);
            });
        }
    }
}
