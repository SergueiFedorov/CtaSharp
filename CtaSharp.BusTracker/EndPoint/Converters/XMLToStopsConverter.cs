using CtaSharp.BusTracker.Models;
using CtaSharp.Shared.Interfaces;
using System;
using System.Collections.Generic;

namespace CtaSharp.BusTracker.EndPoint.Converters
{
    class XMLToStopsConverter : IConverter<Direction>
    {
        public IEnumerable<Direction> Convert(string XML, string parentNodeName)
        {
            throw new NotImplementedException();
        }
    }
}
