using CtaSharp.BusTracker.Models;
using CtaSharp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using CtaSharp.Shared;
using CtaSharp.Tools.XML;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    internal class XMLToVehicleConverter : IConverter<Vehicle>
    {
        public IEnumerable<Vehicle> Convert(string XML, string parentNodeName)
        {
			if (string.IsNullOrEmpty (XML) || string.IsNullOrEmpty (parentNodeName)) 
			{
				throw new ArgumentNullException ();
			}

			var parsedXML = XDocument.Parse(XML);
			//var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
			var vehicles = parsedXML.Descendants().SelectMany(x => x.Descendants().Where(y => y.Name == "vehicle"));

			var returnList = new List<Vehicle> ();

			foreach (var vehicleXML in vehicles) {
				Vehicle vehicle = new Vehicle ();

				vehicle.VehicleId = 		XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue (vehicleXML, "vid"));
				vehicle.TimeStamp = 		XMLParsingTools.ParseBusDateTime(XMLParsingTools.ExtractValue (vehicleXML, "tmstmp"));
				vehicle.Latitude =  		XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue (vehicleXML, "lat"));
				vehicle.Longitude = 		XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue  (vehicleXML, "lon"));
				vehicle.HeadingDegrees =  	XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue (vehicleXML, "hdg"));
				vehicle.ParentPatternID = 	XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue (vehicleXML, "pid"));
				vehicle.ParentDistance = 	XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue (vehicleXML, "pdist"));
				vehicle.Route = 			XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue (vehicleXML, "rt"));
				vehicle.Destination = 		XMLParsingTools.ExtractValue (vehicleXML, "des");
				//vehicle.Delayed = 			XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue (vehicleXML, "dly"));
			
				returnList.Add (vehicle);
			}

			return returnList;
        }
    }
}
