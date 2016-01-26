using CtaSharp.BusTracker.Models;
using CtaSharp.Shared.Interfaces;
using CtaSharp.Tools.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    class XMLToRouteConverter : IConverter<Route>
    {
        public IEnumerable<Route> Convert(string XML, string parentNodeName)
        {
            if (string.IsNullOrEmpty(XML) || string.IsNullOrEmpty(parentNodeName))
            {
                throw new ArgumentNullException();
            }

            var parsedXML = XDocument.Parse(XML);
            var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
            var routes = parentNode.SelectMany(x => x.Descendants().Where(y => y.Name == "route"));

            var returnList = new List<Route>();
            foreach (var route in routes)
            {
                Route newRoute = new Route();

                newRoute.Name =     XMLParsingTools.ExtractValue(route, "rtnm");
                newRoute.ColorHex = XMLParsingTools.ExtractValue(route, "rtclr");
                newRoute.RouteID =  XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(route, "rt"));

                returnList.Add(newRoute);
            }

            return returnList;
        }
    }
}
