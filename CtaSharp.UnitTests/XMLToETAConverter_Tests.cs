using System;
using NUnit.Framework;
using NUnit;
using CtaSharp.EndPoint.Converters;
using System.Linq;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	public class XMLToETAConverter_Tests
	{

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullXmlDataString()
		{
			XMLToETAConverter converter = new XMLToETAConverter ();
			converter.Convert (null, "parentNode");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullParentNodeString()
		{
			XMLToETAConverter converter = new XMLToETAConverter ();
			converter.Convert (TestHelper.ETADataString, null);
		}

		[Test]
		public void BasicConversion()
		{

			XMLToETAConverter conveter = new XMLToETAConverter ();
			var result = conveter.Convert (TestHelper.ETADataString, "ctatt").First();

			Assert.AreEqual (40010, result.StationID);
			Assert.AreEqual (30001, result.StopID);
			Assert.AreEqual ("Austin", result.StationName);
			Assert.AreEqual ("Austin to O'Hare", result.StationDescription);
			Assert.AreEqual ("Blue Line", result.RouteName);
			Assert.AreEqual (30171, result.DestinationStationID);
			Assert.AreEqual ("O'Hare", result.DestinationName);
			Assert.AreEqual (1, result.RouteDirectionCode);
			Assert.AreEqual (new DateTime(2013,05,15,14,10,23), result.PredicationGeneratedTime);
			Assert.AreEqual (new DateTime(2013,05,15,14,11,23), result.PredicatedArrival);
			Assert.AreEqual (true, result.IsApproaching);
			Assert.AreEqual (false, result.IsLivePrediction);
			Assert.AreEqual (false, result.IsDelayed);
			Assert.AreEqual (false, result.IsFaultDetected);
			Assert.AreEqual ("", result.Flags);
		}
	}
}

