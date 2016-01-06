using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.Parameters
{
    public enum TrainRoute { Red }
    public class RouteParameters
    {
        public TrainRoute Route { get; set; }
    }
}
