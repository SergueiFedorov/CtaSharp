using CtaSharp.BusTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.BusTracker.Models
{
    public class Pattern
    {
        public int PatternID { get; set; }
        public DirectionEnum Direction { get; set; }
        public int StopID { get; set; }
        public IEnumerable<GeoPoint> GeoPoints { get; set; }
    }
}
