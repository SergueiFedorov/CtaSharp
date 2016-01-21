using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.Parameters;
using System;

namespace CtaSharp.Models
{
	public class Train : ModelBase<Train>
    {
        internal Train(Route route)
        {
            this.Route = route;
        }

        public Route Route { get; set; }
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

		internal override void UpdateWith (Train obj)
		{
			this.UpdatedTime = DateTime.Now;

			this.Route = obj.Route;
			this.RunNumber = obj.RunNumber;
			this.DestinationStopNumber = obj.DestinationStopNumber;
			this.TrainDirection = obj.TrainDirection;
			this.DestinationName = obj.DestinationName;
			this.NextStationID = obj.NextStationID;
			this.NextStopID = obj.NextStopID;
			this.NextStationName = obj.NextStationName;
			this.PredicationGeneratedTime = obj.PredicationGeneratedTime;
			this.PredicatedArrival = obj.PredicatedArrival;
			this.IsApproaching = obj.IsApproaching;
			this.IsDelayed = obj.IsDelayed;
			this.Flags = obj.Flags;
			this.TrainLatitude = obj.TrainLatitude;
			this.TrainLongitude = obj.TrainLongitude;
			this.HeadingDegrees = obj.HeadingDegrees;
		}
    }
}
