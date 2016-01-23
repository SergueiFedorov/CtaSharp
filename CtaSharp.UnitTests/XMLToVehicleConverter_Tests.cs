using System;
using System.Linq;
using CtaSharp.BusTracker.EndPoint.Converters;
using NUnit;
using NUnit.Framework;

namespace CtaSharp.UnitTests
{
	/*
	public const string BusVehicleString =
	@"<bustime-response>
    <vehicle>
	    <vid>1369</vid>
	    <tmstmp>20160121 21:26</tmstmp>
	    <lat>41.865718841552734</lat>
	    <lon>-87.7553244925834</lon>
	    <hdg>89</hdg>
	    <pid>4135</pid>
	    <rt>12</rt>
	    <des>15th/Indiana</des>
	    <pdist>5238</pdist>
	    <spd>0</spd>
	    <tablockid>12 -209</tablockid>
	    <tatripid>1074820</tatripid>
	    <zone/>
    </vehicle>
</bustime-response>";*/
	

	[TestFixture]
	public class XMLToVehicleConverter_Tests
	{
		[Test]
		public void BasicConversion()
		{
			XMLToVehicleConverter converter = new XMLToVehicleConverter ();
			var conversionResult = converter.Convert (TestHelper.BusVehicleString, " ");

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

