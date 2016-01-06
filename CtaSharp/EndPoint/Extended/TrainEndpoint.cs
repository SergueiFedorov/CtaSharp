using CtaSharp.Models;
using CtaSharp.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CtaSharp
{
    internal class TrainEndpointXML : IEndpoint<Train, TrainParameters>
    {
        IEndpoint<Route, RouteParameters> _routeEndpoint { get; }
        EnumTrainRoute _route { get; }

        internal TrainEndpointXML(IEndpoint<Route, RouteParameters> routeEndpoint, EnumTrainRoute route)
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
