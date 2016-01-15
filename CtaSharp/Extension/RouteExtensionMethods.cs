using System;
using System.Threading.Tasks;
using System.Linq;
using CtaSharp.Models;
using CtaSharp.Parameters;
using CtaSharp.EndPoint;

namespace CtaSharp
{
	public static class RouteExtensionMethods
	{
		public static bool TryRefresh(this Route route)
		{
			var result = route.EndPoint.Get (new RouteParameters () { Route = route.TrainRoute }).SingleOrDefault();
		
			if (result != null) {
				route.UpdateWith (result);

				return true;
			}
			return false;
		}

		public static async Task<bool> TryRefreshAsync(this Route route)
		{
			return await Task.Run (() => {
				return route.TryRefresh();
			});
		}
	}
}

