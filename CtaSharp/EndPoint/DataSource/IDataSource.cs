using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint.DataSource
{
    internal interface IDataSource<T>
    {
        void AddParameter(string name, string value);
        string Execute();
    }
}
