using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace CtaSharp.EndPoint.DataSource
{
    internal interface IDataSource
    {
        void AddParameter(string name, string value);
        string Execute();
    }
}
