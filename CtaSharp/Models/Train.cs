using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.Parameters;
using System;

namespace CtaSharp.Models
{
    public class Train
    {
        internal IDataSource DataSource { set; get; }
        internal IXmlConverter<Route> RouteConverter { set;  get; }

        internal Train(Route route, IDataSource dataSource, IXmlConverter<Route> converter)
        {
            this.Route = route;
            DataSource = dataSource;
            RouteConverter = converter;
        }

        public Train()
        {

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
    }
}
