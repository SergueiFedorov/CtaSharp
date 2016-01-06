using CtaSharp.Tools.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CtaSharp.EndPoint.XML.Converters
{
    internal class XMLToTrainConverter : IXmlConverter<Train>
    {
        public IEnumerable<Train> Convert(string XML, string parentNodeName)
        {
            var parsedXML = XDocument.Parse(XML);
            var trains = parsedXML.Descendants().Where(x => x.Name == parentNodeName);

            List<Train> parsedTrains = new List<Train>();
            foreach (XElement train in trains)
            {
                parsedTrains.Add(new Train()
                {
                    DestinationName =           XMLParsingTools.ExtractValue(train, "destNm"),
                    RunNumber =                 XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "rn")),
                    DestinationStopNumber =     XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "destSt")),
                    IsApproaching =             XMLParsingTools.PraseBool(XMLParsingTools.ExtractValue(train, "isApp")),
                    IsDelayed =                 XMLParsingTools.PraseBool(XMLParsingTools.ExtractValue(train, "isDly")),
                    HeadingDegrees =            XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(train, "heading")),
                    TrainLongitude =            XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue(train, "lon")),
                    TrainLatitude =             XMLParsingTools.ParseDecimal(XMLParsingTools.ExtractValue(train, "lat")),
                    TrainDirection =            XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(train, "trDr")),
                    PredicationGeneratedTime =  XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(train, "prdt")),
                    PredicatedArrival =         XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(train, "arrT")),
                    NextStationID =             XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "nextStaId")),
                    NextStopID =                XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(train, "nextStpId")),
                    NextStationName =           XMLParsingTools.ExtractValue(train, "nextStaNm"),
                    Flags =                     XMLParsingTools.ExtractValue(train, "flags")
                });

            }

            return parsedTrains;
        }
    }
}
