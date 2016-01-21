using System;
using CtaSharp.Enums;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.EndPoint;
using CtaSharp.Parameters;

namespace CtaSharp.Models
{
	public class ETA : ModelBase<ETA>
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

		internal override void UpdateWith (ETA obj)
		{
			this.StationID = obj.StationID;
			this.DestinationName = obj.DestinationName;
			this.DestinationStationID = obj.DestinationStationID;
			this.Flags = obj.Flags;
			this.IsApproaching = obj.IsApproaching;
			this.IsDelayed = obj.IsDelayed;
			this.IsFaultDetected = obj.IsFaultDetected;
			this.IsLivePrediction = obj.IsLivePrediction;
			this.PredicatedArrival = obj.PredicatedArrival;
			this.PredicationGeneratedTime = obj.PredicationGeneratedTime;
			this.Route = obj.Route;
			this.RouteDirectionCode = obj.RouteDirectionCode;
			this.RouteName = obj.RouteName;
			this.RunNumber = obj.RunNumber;
			this.StationDescription = obj.StationDescription;
			this.StationName = obj.StationName;
			this.StopID = obj.StopID;
			this.UpdatedTime = DateTime.Now;
		}
    }
}
