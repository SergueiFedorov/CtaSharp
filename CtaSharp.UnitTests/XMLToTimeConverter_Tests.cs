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
    public class XMLToTimeConverter_Tests
    {
        [Test]
        public void BasicConversion()
        {
            XMLToTimeConverter converter = new XMLToTimeConverter();
            var conversionResult = converter.Convert(TestHelper.TimeString, "bustime-response");

            Assert.AreEqual(new DateTime(2016, 1, 27, 21, 31, 0), conversionResult.First().TimeValue);
        }
    }
}
