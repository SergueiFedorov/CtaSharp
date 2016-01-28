using CtaSharp.Shared;
using CtaSharp.Shared.Interfaces;

namespace CtaSharp.BusTracker.DataSource
{
    class VehicleDataSource : DataSourceBase, IDataSource
    {
        const string EndpointAddress = "http://www.ctabustracker.com/bustime/api/v1/getvihicles";

        public VehicleDataSource()
            : base(EndpointAddress)
        {

        }
    }
}
