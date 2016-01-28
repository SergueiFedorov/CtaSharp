using System;
using System.Linq;
using CtaSharp.BusTracker.EndPoint.Converters;
using NUnit;
using NUnit.Framework;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	public class XMLToVehicleConverter_Tests
	{
		[Test]
		public void BasicConversion()
		{
			XMLToVehicleConverter converter = new XMLToVehicleConverter ();
			var conversionResult = converter.Convert (TestHelper.BusVehicleString, "bustime-response");

			var firstElement = conversionResult.First ();

			Assert.AreEqual (1369, firstElement.VehicleId);
			Assert.AreEqual (41.865718841552734m, firstElement.Latitude);
			Assert.AreEqual (-87.7553244925834m, firstElement.Longitude);
			Assert.AreEqual (89, firstElement.HeadingDegrees);
			Assert.AreEqual (4135, firstElement.ParentPatternID);
			Assert.AreEqual ("15th/Indiana", firstElement.Destination);
			Assert.AreEqual (5238, firstElement.ParentDistance);
			Assert.AreEqual (0, firstElement.Speed);
		}
	}
}

