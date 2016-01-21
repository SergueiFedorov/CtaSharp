using CtaSharp.BusTracker.Models;
using CtaSharp.BusTracker.Parameters;
using CtaSharp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.BusTracker.EndPoint
{
    class VehicleEndpoint : IEndpoint<Vehicle, VehicleParameters>
    {
        public IEnumerable<Vehicle> Get(VehicleParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetAsync(VehicleParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
