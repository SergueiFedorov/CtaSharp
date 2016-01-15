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
        public static bool TryRefresh(this Train train)
        {
            IEndpoint<Route, RouteParameters> endpoint = train.Route.EndPoint;
            var result = endpoint.Get(new RouteParameters() { Route = train.Route.TrainRoute });

			if (result.Any ()) {
				var updatedTrain = result.SelectMany(x => x.Trains).SingleOrDefault(x => x.RunNumber == train.RunNumber);
				train.UpdateWith (updatedTrain);

				return true;
			}

			return false;
        }

		public static async Task<bool> TryRefreshAsync(this Train train)
		{
			return await Task.Run (() => {
				return train.TryRefresh();
			});
		}
    }
}
