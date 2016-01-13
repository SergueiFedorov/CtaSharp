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
    internal class RouteEndPointXML : IEndpoint<Route, RouteParameters>
    {
        IXmlConverter<Route> _RouteConverter { get; }
        IDataSource _RouteDataSource { get; set; }

		string _APIKey { get; }

		internal RouteEndPointXML(string APIKey)
        {
			_APIKey = APIKey;
			_RouteDataSource = new RouteDataSource ();
			_RouteConverter = new XMLToRouteConverter();
        }

		internal RouteEndPointXML(string APIKey, IXmlConverter<Route> routeConverter, IDataSource dataSource)
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
            foreach (var train in route.SelectMany(x => x.Trains))
            {
                train.RouteConverter = _RouteConverter;
                train.DataSource = _RouteDataSource;
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
