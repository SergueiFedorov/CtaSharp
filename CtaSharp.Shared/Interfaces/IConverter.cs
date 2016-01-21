using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace CtaSharp.Shared.Interfaces
{
    public interface IXmlConverter<T>
    {
        IEnumerable<T> Convert(string XML, string parentNodeName);
    }
}
