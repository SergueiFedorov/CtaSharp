using System.Collections.Generic;
using CtaSharp.Parameters;
using CtaSharp.Enums;
using System;
using CtaSharp.Shared.Interfaces;

namespace CtaSharp.Models
{
	public class Route : ModelBase<Route>
    {
        internal IEndpoint<Route, RouteParameters> EndPoint { get; set; }

		public EnumTrainRoute TrainRoute { get; set; }
        public IEnumerable<Train> Trains { get; set; }

		internal override void UpdateWith (Route obj)
		{
			this.EndPoint = obj.EndPoint;
			this.TrainRoute = obj.TrainRoute;
			this.Trains = obj.Trains;
			this.UpdatedTime = DateTime.Now;
		}
    }
}
