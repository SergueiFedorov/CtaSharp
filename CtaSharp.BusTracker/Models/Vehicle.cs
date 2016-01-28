using System;

namespace CtaSharp.BusTracker.Models
{
	public class Vehicle
    {
		public int VehicleId { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public int HeadingDegrees { get; set; }
		public int Route { get; set; }
		public string Destination { get; set; }
		public int Speed { get; set; }
		public int ParentPatternID { get; set; }
		public int ParentDistance { get; set; }
		public bool Delayed { get; set; }
		public DateTime TimeStamp { get; set; }
    }
}
