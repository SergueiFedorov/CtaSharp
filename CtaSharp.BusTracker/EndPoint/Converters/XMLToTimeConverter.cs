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
    class XMLToTimeConverter : IConverter<Time>
    {
        public IEnumerable<Time> Convert(string XML, string parentNodeName)
        {
            if (string.IsNullOrEmpty(XML) || string.IsNullOrEmpty(parentNodeName))
            {
                throw new ArgumentNullException();
            }

            var parsedXML = XDocument.Parse(XML);
            var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
            var times = parentNode.SelectMany(x => x.Descendants().Where(y => y.Name == "tm"));

            var returnList = new List<Time>();
            foreach (var time in times)
            {
                returnList.Add(new Time()
                {
                    TimeValue = XMLParsingTools.ParseBusDateTime(XMLParsingTools.ExtractValue(time))
                });
            }

            return returnList;
        }
    }
}
