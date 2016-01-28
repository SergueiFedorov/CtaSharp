using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;

namespace CtaSharp.BusTracker.EndPoint.DataSource
{
    class TimeDataSource : DataSourceBase, IDataSource
    {
        const string EndPointAddress = "http://www.ctabustracker.com/bustime/api/v1/gettime";

        public TimeDataSource()
            : base("EndPointAddress")
        {

        }
    }
}
