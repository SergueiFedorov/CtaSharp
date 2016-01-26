using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.BusTracker.EndPoint.DataSource
{
    class RoutesDataSource : DataSourceBase, IDataSource
    {
        const string EndpointAddress = "http://www.ctabustracker.com/bustime/api/v1/getroutes";

        public RoutesDataSource()
            : base(EndpointAddress)
        {

        }
    }
}
