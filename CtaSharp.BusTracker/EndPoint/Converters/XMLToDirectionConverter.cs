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
    class XMLToDirectionConverter : IConverter<Direction>
    {
        private DirectionEnum ConvertToDirectionEnum(string text)
        {
            switch(text.ToLower())
            {
                case "eastbound":
                    {
                        return DirectionEnum.East;
                    }
                case "westbound":
                    {
                        return DirectionEnum.West;
                    }
                case "southbound":
                    {
                        return DirectionEnum.South;
                    }
                case "northbound":
                    {
                        return DirectionEnum.North;
                    }
                default:
                    {
                        throw new InvalidOperationException("Unsupported direction");
                    }
            }
        }

        public IEnumerable<Direction> Convert(string XML, string parentNodeName)
        {
            if (string.IsNullOrEmpty(XML) || string.IsNullOrEmpty(parentNodeName))
            {
                throw new ArgumentNullException();
            }

            var parsedXML = XDocument.Parse(XML);
            var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
            var directions = parentNode.SelectMany(x => x.Descendants().Where(y => y.Name == "dir"));

            var returnList = new List<Direction>();
            foreach (var direction in directions)
            {
                returnList.Add(new Direction()
                {
                    DirectionSpecification = ConvertToDirectionEnum(XMLParsingTools.ExtractValue(direction))
                });
            }

            return returnList;
        }
    }
}
