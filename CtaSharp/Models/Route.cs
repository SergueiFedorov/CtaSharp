using System.Collections.Generic;
using CtaSharp;
using CtaSharp.Parameters;
using CtaSharp.EndPoint;
using CtaSharp.Enums;


namespace CtaSharp.Models
{
    public class Route
    {
		public EnumTrainRoute TrainRoute { get; set; }
        public IEnumerable<Train> Trains { get; set; }
    }
}
