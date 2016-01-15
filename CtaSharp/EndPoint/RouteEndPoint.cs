using CtaSharp.Models;
using CtaSharp.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using System.Runtime.CompilerServices;
using System.Linq;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint
{
    internal class RouteEndPoint : IEndpoint<Route, RouteParameters>
    {
        IXmlConverter<Route> _RouteConverter { get; }
        IDataSource _RouteDataSource { get; set; }

		string _APIKey { get; }

		internal RouteEndPoint(string APIKey)
        {
			_APIKey = APIKey;
			_RouteDataSource = new RouteDataSource ();
			_RouteConverter = new XMLToRouteConverter();
        }

		internal RouteEndPoint(string APIKey, IXmlConverter<Route> routeConverter, IDataSource dataSource)
        {
			if (routeConverter == null || dataSource == null || string.IsNullOrEmpty(APIKey)) {
				throw new ArgumentNullException ();
			}

			_RouteDataSource = dataSource;
			_RouteConverter = routeConverter;
        }

        public IEnumerable<Route> Get(RouteParameters parameters)
        {
			string routeName = RouteHelper.GetTrainRouteString(parameters.Route);
			_RouteDataSource.AddParameter("rt", routeName);
			_RouteDataSource.AddParameter ("key", _APIKey);

			var data = _RouteDataSource.Execute();
			var route = _RouteConverter.Convert(data, "ctatt");

            //Inject dependencies.
            //Todo: must be a cleaner way to do this
            foreach (var routeToInject in route)
            {
                routeToInject.EndPoint = this;
            }

			return route;
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
