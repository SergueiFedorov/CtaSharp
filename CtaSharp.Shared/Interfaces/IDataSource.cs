using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace CtaSharp.EndPoint.DataSource
{
	public interface IDataSource
    {
        void AddParameter(string name, string value);
        void ClearParameters();
        string Execute();
    }
}
