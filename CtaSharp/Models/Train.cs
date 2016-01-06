using System;

namespace CtaSharp
{
    public class Train
    {
        public ushort RunNumber { get; set; }
        public ushort DestinationStopNumber { get; set; }
        public int TrainDirection { get; set; }
        public string DestinationName { get; set; }
        public int NextStationID { get; set; }
        public int NextStopID { get; set; }
        public string NextStationName { get; set; }
        public DateTime PredicationGeneratedTime { get; set; }
        public DateTime PredicatedArrival { get; set; }
        public bool IsApproaching { get; set; }
        public bool IsDelayed { get; set; }
        public string Flags { get; set; }
        public decimal TrainLatitude { get; set; }
        public decimal TrainLongitude { get; set; }
        public int HeadingDegrees { get; set; }
    }
}
