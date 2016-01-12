using System;
using CtaSharp.Enums;

namespace CtaSharp.Models
{
    public class ETA
    {
        public int StationID { get; set; }
        public int StopID { get; set; }
        public string StationName { get; set; }
        public string StationDescription { get; set; }
        public int RunNumber { get; set; }
        public string RouteName { get; set; }
        public int DestinationStationID { get; set; }
        public string DestinationName { get; set; }
        public int RouteDirectionCode { get; set; }
        public DateTime PredicationGeneratedTime { get; set; }
        public DateTime PredicatedArrival { get; set; }
        public bool IsApproaching { get; set; }
        public bool IsLivePrediction { get; set; }
        public bool IsDelayed { get; set; }
        public bool IsFaultDetected { get; set; }
        public string Flags { get; set; }
        public EnumTrainRoute Route { get; internal set; }
    }
}
