using CtaSharp.BusTracker.EndPoint.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.UnitTests
{
    [TestFixture]
    public class XmlToRouteConverter_Bus_Tests
    {
        [Test]
        public void BasicConvert()
        {
            XMLToRouteConverter converter = new XMLToRouteConverter();
            var result = converter.Convert(TestHelper.BusRouteString, "bustime-response");

            var route = result.First();

            Assert.AreEqual(1, route.RouteID);
            Assert.AreEqual("Bronzeville/Union Station", route.Name);
            Assert.AreEqual("#336633", route.ColorHex);
        }
    }
}
