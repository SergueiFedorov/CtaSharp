using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.EndPoint.Converters
{
    internal interface IXmlConverter<T>
    {
        IEnumerable<T> Convert(string XML, string parentNodeName);
    }
}
