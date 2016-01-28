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
    public class XMLToDirectionConverter_Tests
    {
        [Test]
        public void BasicConverstion()
        {
            XMLToDirectionConverter converter = new XMLToDirectionConverter();
            var result = converter.Convert(TestHelper.BusDirectionString, "bustime-response");

            Assert.IsTrue(result.Any(x => x.DirectionSpecification == BusTracker.Models.DirectionEnum.East));
            Assert.IsTrue(result.Any(x => x.DirectionSpecification == BusTracker.Models.DirectionEnum.West));
        }
    }
}
