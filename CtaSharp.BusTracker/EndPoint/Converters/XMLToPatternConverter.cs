using CtaSharp.BusTracker.Models;
using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;
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
            : base("pt")
        {

        }

        protected override Pattern ConvertItem(XElement XMLElement)
        {
            throw new NotImplementedException();
        }
    }
}
