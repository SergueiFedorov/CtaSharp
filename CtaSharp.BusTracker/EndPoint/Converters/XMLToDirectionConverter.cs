using CtaSharp.BusTracker.Models;
using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;
using CtaSharp.Tools.XML;
using System;
using System.Xml.Linq;

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    public class XMLToDirectionConverter : XMLConverterBase<Direction>, IConverter<Direction>
    {
        public XMLToDirectionConverter()
            : base("dir")
        {

        }

        protected override Direction ConvertItem(XElement XMLElement)
        {
            return new Direction()
            {
                DirectionSpecification = ConvertToDirectionEnum(XMLParsingTools.ExtractValue(XMLElement))
            };
        }

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
    }
}
