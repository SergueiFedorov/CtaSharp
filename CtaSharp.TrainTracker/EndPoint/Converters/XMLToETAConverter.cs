using CtaSharp.Models;
using CtaSharp.Tools.XML;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;
using CtaSharp.Shared.Interfaces;
using CtaSharp.Shared;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.Converters
{
    internal class XMLToETAConverter : XMLConverterBase<ETA>, IConverter<ETA>
    {
        public XMLToETAConverter()
            : base("eta")
        {

        }

        protected override ETA ConvertItem(XElement XMLElement)
        {
            return new ETA()
            {
                PredicatedArrival = XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(XMLElement, "arrT")),
                DestinationName = XMLParsingTools.ExtractValue(XMLElement, "destNm"),
                DestinationStationID = XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(XMLElement, "destSt")),
                Flags = XMLParsingTools.ExtractValue(XMLElement, "flags"),
                IsApproaching = XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(XMLElement, "isApp")),
                IsDelayed = XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(XMLElement, "isDly")),
                IsFaultDetected = XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(XMLElement, "isFlt")),
                IsLivePrediction = XMLParsingTools.ParseBool(XMLParsingTools.ExtractValue(XMLElement, "isSch")),
                PredicationGeneratedTime = XMLParsingTools.PraseDateTime(XMLParsingTools.ExtractValue(XMLElement, "prdt")),
                RunNumber = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "rn")),
                RouteName = XMLParsingTools.ExtractValue(XMLElement, "rt"),
                StationID = XMLParsingTools.ParseUShort(XMLParsingTools.ExtractValue(XMLElement, "staId")),
                StationName = XMLParsingTools.ExtractValue(XMLElement, "staNm"),
                StationDescription = XMLParsingTools.ExtractValue(XMLElement, "stpDe"),
                StopID = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "stpId")),
                RouteDirectionCode = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "trDr")),
            };
        }
    }
}
