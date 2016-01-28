using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CtaSharp.BusTracker.Parameters
{
    public class VehicleParameters
    {
		public VehicleParameters()
		{
			_VehicleIds = new List<int>();
			_RouteIds = new List<int>();
		}

		private List<int> _VehicleIds { 
			get;
			set;
		}

		private List<int> _RouteIds { 
			get; 
			set;
		}

		public ImmutableList<int> VehicleIds
		{
			get {
				return ImmutableList.Create (_VehicleIds.ToArray());
			}
		}

		public  ImmutableList<int>  RouteIds
		{
			get {
				return ImmutableList.Create (_RouteIds.ToArray());
			}
		}

		public void AddVehicleId (int id)
		{
			if (_RouteIds.Count > 0) {
				throw new InvalidOperationException ("Cannot specify both VehicleIds and RouteIds");
			}

			_VehicleIds.Add (id);
		}

		public void AddRouteId (int id)
		{
			if (_VehicleIds.Count > 0) {
				throw new InvalidOperationException ("Cannot specify both VehicleIds and RouteIds");
			}

			_RouteIds.Add (id);
		}
    }
}
