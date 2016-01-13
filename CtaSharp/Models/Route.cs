using System.Collections.Generic;
using CtaSharp;
using CtaSharp.Parameters;
using CtaSharp.EndPoint;
using CtaSharp.Enums;


namespace CtaSharp.Models
{
    public class Route
    {
        internal IEndpoint<Route, RouteParameters> EndPoint { get; set; }

		public EnumTrainRoute TrainRoute { get; set; }
        public IEnumerable<Train> Trains { get; set; }
    }
}
