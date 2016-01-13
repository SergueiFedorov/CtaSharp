using System;
using System.Linq;
using CtaSharp.Models;
using CtaSharp.Parameters;
using CtaSharp.EndPoint;

namespace CtaSharp
{
	public static class RouteExtensionMethods
	{
		public static void Refresh(this Route route)
		{
			var result = route.EndPoint.Get (new RouteParameters () { Route = route.TrainRoute }).SingleOrDefault();

			if (result == null)
			{
				throw new Exception ("Unable to refresh route. No results returned endpoint.");
			}

			route.UpdateWith (result);
		}
	}
}

