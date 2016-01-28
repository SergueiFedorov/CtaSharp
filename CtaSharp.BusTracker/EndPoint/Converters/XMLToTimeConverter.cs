using CtaSharp.BusTracker.Models;
using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;
using CtaSharp.Tools.XML;
using System.Xml.Linq;

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    class XMLToTimeConverter : XMLConverterBase<Time>, IConverter<Time>
    {
        public XMLToTimeConverter()
            : base("tm")
        {

        }

        protected override Time ConvertItem(XElement XMLElement)
        {
            return new Time()
            {
                TimeValue = XMLParsingTools.ParseBusDateTime(XMLParsingTools.ExtractValue(XMLElement))
            };
        }
    }
}
