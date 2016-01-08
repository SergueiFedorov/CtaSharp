using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.EndPoint.DataSource
{
    interface IDataSource<T>
    {
        void AddParameter(string name, string value);
        string Execute();
    }
}
