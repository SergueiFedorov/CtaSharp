using CtaSharp.BusTracker.Models;
using CtaSharp.Shared;
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
    public class XMLToPatternConverter : XMLConverterBase<Pattern>, IConverter<Pattern>
    {
        public XMLToPatternConverter()
            : base("ptr")
        {

        }

        public override IEnumerable<Pattern> Convert(string XML, string parentNodeName)
        {
            if (string.IsNullOrEmpty(XML) || string.IsNullOrEmpty(parentNodeName))
            {
                throw new ArgumentNullException();
            }

            var parsedXML = XDocument.Parse(XML);
            var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
            var items = parentNode.SelectMany(x => x.Descendants().Where(y => y.Name == _elementName));

            //XMLParsingTools.ParseInt(XMLParsingTools.ExtractValue(parentNode, "pid"));

            throw new NotSupportedException();
        }

        protected override Pattern ConvertItem(XElement XMLElement)
        {
            throw new NotSupportedException();
        }
    }
}
