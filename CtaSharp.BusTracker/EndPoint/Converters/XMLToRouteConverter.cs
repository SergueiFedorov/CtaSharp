using CtaSharp.BusTracker.Models;
using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;
using CtaSharp.Tools.XML;
using System.Xml.Linq;

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    class XMLToRouteConverter : XMLConverterBase<Route>, IConverter<Route>
    {
        public XMLToRouteConverter()
            : base("route")
        {

        }

        protected override Route ConvertItem(XElement XMLElement)
        {
            Route newRoute = new Route();

            newRoute.Name = XMLParsingTools.ExtractValue(XMLElement, "rtnm");
            newRoute.ColorHex = XMLParsingTools.ExtractValue(XMLElement, "rtclr");
            newRoute.RouteID = XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(XMLElement, "rt"));

            return newRoute;
        }
    }
}
