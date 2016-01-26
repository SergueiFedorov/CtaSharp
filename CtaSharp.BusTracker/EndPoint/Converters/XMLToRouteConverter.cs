using CtaSharp.BusTracker.Models;
using CtaSharp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    class XMLToRouteConverter : IConverter<Route>
    {
        public IEnumerable<Route> Convert(string XML, string parentNodeName)
        {
            throw new NotImplementedException();
        }
    }
}
