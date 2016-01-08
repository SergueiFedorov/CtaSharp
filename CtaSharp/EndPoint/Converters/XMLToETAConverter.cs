using CtaSharp.Models;
using CtaSharp.Tools.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CtaSharp.EndPoint.Converters
{
    internal class XMLToETAConverter : IXmlConverter<ETA>
    {
        public IEnumerable<ETA> Convert(string XML, string parentNodeName)
        {
            var parsedXML = XDocument.Parse(XML);
            var etas = parsedXML.Descendants().Where(x => x.Name == parentNodeName);

            List<ETA> parsedETA = new List<ETA>();
            foreach (XElement eta in etas)
            {
                parsedETA.Add(new ETA()
                {
                    PredicatedArrival =      XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(eta, "arrT")),
                    DestinationName =    XMLParsingTools.ExtractValue(eta, "destNm"),
                    DestinationStationID =    XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(eta, "destSt")),
                    Flags =     XMLParsingTools.ExtractValue(eta, "flags"),
                    IsApproaching =     XMLParsingTools.PraseBool(XMLParsingTools.ExtractValue(eta, "isApp")),
                    IsDelayed =     XMLParsingTools.PraseBool(XMLParsingTools.ExtractValue(eta, "isDly")),
                    IsFaultDetected =     XMLParsingTools.PraseBool(XMLParsingTools.ExtractValue(eta, "isFlt")),
                    IsLivePrediction =     XMLParsingTools.PraseBool(XMLParsingTools.ExtractValue(eta, "isSch")),
                    PredicationGeneratedTime =      XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(eta, "prdt")),
                    RunNumber =        XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(eta, "rn")),
                    RouteName =        XMLParsingTools.ExtractValue(eta, "rt"),
                    StationID =     XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(eta, "staId")),
                    StationName =     XMLParsingTools.ExtractValue(eta, "staNm"),
                    StationDescription =     XMLParsingTools.ExtractValue(eta, "stpDe"),
                    StopID =     XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(eta, "stpId")),
                    RouteDirectionCode =      XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(eta, "trDr")),
                });

            }

            return parsedETA;
        }
    }
}
