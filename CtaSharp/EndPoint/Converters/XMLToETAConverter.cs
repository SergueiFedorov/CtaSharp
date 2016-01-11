using CtaSharp.Models;
using CtaSharp.Tools.XML;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.Converters
{
    internal class XMLToETAConverter : IXmlConverter<ETA>
    {
        public IEnumerable<ETA> Convert(string XML, string parentNodeName)
        {
			if (string.IsNullOrEmpty (XML) || string.IsNullOrEmpty (parentNodeName)) 
			{
				throw new ArgumentNullException ();
			}

            var parsedXML = XDocument.Parse(XML);
            var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
            var etas = parentNode.SelectMany(x => x.Descendants().Where(y => y.Name == "eta"));


            List<ETA> parsedETA = new List<ETA>();
            foreach (XElement eta in etas)
            {
                parsedETA.Add(new ETA()
                {
                    PredicatedArrival =      	XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(eta, "arrT")),
                    DestinationName =    		XMLParsingTools.ExtractValue(eta, "destNm"),
                    DestinationStationID =    	XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(eta, "destSt")),
                    Flags =     				XMLParsingTools.ExtractValue(eta, "flags"),
                    IsApproaching =     		XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(eta, "isApp")),
                    IsDelayed =     			XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(eta, "isDly")),
                    IsFaultDetected =     		XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(eta, "isFlt")),
                    IsLivePrediction =     		XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(eta, "isSch")),
            		PredicationGeneratedTime = 	XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(eta, "prdt")),
                    RunNumber =        			XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(eta, "rn")),
                    RouteName =        			XMLParsingTools.ExtractValue(eta, "rt"),
                    StationID =     			XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(eta, "staId")),
                    StationName =     			XMLParsingTools.ExtractValue(eta, "staNm"),
                	StationDescription =     	XMLParsingTools.ExtractValue(eta, "stpDe"),
                    StopID =     				XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(eta, "stpId")),
                    RouteDirectionCode =      	XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(eta, "trDr")),
                });

            }

            return parsedETA;
        }
    }
}
