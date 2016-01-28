using CtaSharp.BusTracker.Models;
using CtaSharp.Shared.Interfaces;
using System.Xml.Linq;
using CtaSharp.Tools.XML;
using System.Runtime.CompilerServices;
using CtaSharp.Shared;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    internal class XMLToVehicleConverter : XMLConverterBase<Vehicle>, IConverter<Vehicle>
    {
        public XMLToVehicleConverter()
            : base("vehicle")
        {

        }

        protected override Vehicle ConvertItem(XElement XMLElement)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.VehicleId = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "vid"));
            vehicle.TimeStamp = XMLParsingTools.ParseBusDateTime(XMLParsingTools.ExtractValue(XMLElement, "tmstmp"));
            vehicle.Latitude = XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue(XMLElement, "lat"));
            vehicle.Longitude = XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue(XMLElement, "lon"));
            vehicle.HeadingDegrees = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "hdg"));
            vehicle.ParentPatternID = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "pid"));
            vehicle.ParentDistance = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "pdist"));
            vehicle.Route = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "rt"));
            vehicle.Destination = XMLParsingTools.ExtractValue(XMLElement, "des");

            return vehicle;
        }
    }
}
