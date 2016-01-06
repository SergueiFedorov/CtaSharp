using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.Parameters
{
    public enum EnumTrainRoute { Red }
    public class RouteParameters
    {
        public EnumTrainRoute Route { get; set; }
    }
}
