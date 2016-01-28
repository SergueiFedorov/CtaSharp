using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.BusTracker.EndPoint.DataSource
{
    public class DirectionDataSource : DataSourceBase, IDataSource
    {
        public const string EndPointAddress = "http://www.ctabustracker.com/bustime/api/v1/getdirections";

        public DirectionDataSource()
            : base(EndPointAddress)
        {

        }
    }
}
