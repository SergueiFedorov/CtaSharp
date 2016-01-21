using CtaSharp.Models;
using CtaSharp.Tools.XML;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;
using CtaSharp.Shared.Interfaces;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.Converters
{
	internal class XMLToRouteConverter : IXmlConverter<Route>
    {
		//Todo: Clean this up
        public IEnumerable<Route> Convert(string XML, string parentNodeName)
        {
			if (string.IsNullOrEmpty (XML) || string.IsNullOrEmpty (parentNodeName)) {
				throw new ArgumentNullException ();
			}

            var parsedXML = XDocument.Parse(XML);

			var routeXelement = parsedXML.Descendants ().Where (x => x.Name == "route").Single();
			var trainsXelements = routeXelement.Descendants().Where(x => x.Name == "train");

			Route route = new Route ();
			var lineName = XMLParsingTools.ExtractAttribute (routeXelement, "name"); 

			route.TrainRoute = RouteHelper.GetTrainRouteEnum (lineName);

            List<Train> parsedTrains = new List<Train>();
			foreach (XElement train in trainsXelements)
            {
				var newTrain = new Train(route)
                {
                    DestinationName = XMLParsingTools.ExtractValue(train, "destNm"),
                    RunNumber = XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "rn")),
                    DestinationStopNumber = XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "destSt")),
                    IsApproaching = XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(train, "isApp")),
                    IsDelayed = XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(train, "isDly")),
                    HeadingDegrees = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(train, "heading")),
                    TrainLongitude = XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue(train, "lon")),
                    TrainLatitude = XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue(train, "lat")),
                    TrainDirection = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(train, "trDr")),
                    PredicationGeneratedTime = XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(train, "prdt")),
                    PredicatedArrival = XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(train, "arrT")),
                    NextStationID = XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "nextStaId")),
                    NextStopID = XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "nextStpId")),
                    NextStationName = XMLParsingTools.ExtractValue(train, "nextStaNm"),
                    Flags = XMLParsingTools.ExtractValue(train, "flags")
                };

                //newTrain.Route = route;
                parsedTrains.Add(newTrain);

            }

			route.Trains = parsedTrains;

			return new Route[] { route };
        }
    }
}
