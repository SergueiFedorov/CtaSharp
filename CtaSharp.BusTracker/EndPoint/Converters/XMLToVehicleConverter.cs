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

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    class XMLToVehicleConverter : IConverter<Vehicle>
    {
        public IEnumerable<Vehicle> Convert(string XML, string parentNodeName)
        {
			if (string.IsNullOrEmpty (XML) || string.IsNullOrEmpty (parentNodeName)) 
			{
				throw new ArgumentNullException ();
			}

			var parsedXML = XDocument.Parse(XML);
			var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
			var vehicles = parentNode.SelectMany(x => x.Descendants().Where(y => y.Name == "vehicle"));

			foreach (var vehicleXML in vehicles) {
				XMLParsingTools.ExtractValue (vehicleXML, "vid");
				XMLParsingTools.ExtractValue (vehicleXML, "tmstmp");
				XMLParsingTools.ExtractValue (vehicleXML, "");
				XMLParsingTools.ExtractValue (vehicleXML, "");
				XMLParsingTools.ExtractValue (vehicleXML, "");
				XMLParsingTools.ExtractValue (vehicleXML, "");
			}

			throw new ArgumentNullException ();
        }
    }
}
