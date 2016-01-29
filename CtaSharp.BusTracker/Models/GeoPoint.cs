using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.BusTracker.Models
{
    public class GeoPoint
    {
        public int Sequence { get; set; }
        public string Type { get; set; }
        public int StopID { get; set; }
        public string StopName { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public Decimal Distance { get; set; }
    }
}
