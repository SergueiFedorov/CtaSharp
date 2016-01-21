using System;
using NUnit.Framework;
using CtaSharp.EndPoint.Converters;
using CtaSharp.Models;
using System.Linq;
using CtaSharp.Enums;
using CtaSharp.Shared.Interfaces;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	public class XMLToRouteConverter_Tests
	{

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullXmlDataString()
		{
			IConverter<Route> converter = new XMLToRouteConverter ();
			converter.Convert (null, "parentNode");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullParentNodeString()
		{
			IConverter<Route> converter = new XMLToRouteConverter ();
			converter.Convert (TestHelper.RouteDataString, null);
		}

		[Test]
		public void BasicConversion()
		{
			IConverter<Route> converter = new XMLToRouteConverter ();
			var result = converter.Convert (TestHelper.RouteDataString, "route").First();

			Assert.IsTrue (result.Trains.Any ());
			Assert.AreEqual (EnumTrainRoute.Red, result.TrainRoute);

			var train = result.Trains.First ();

			Assert.AreEqual (804, train.RunNumber);
			Assert.AreEqual (30173, train.DestinationStopNumber);
			Assert.AreEqual ("Howard", train.DestinationName);
			Assert.AreEqual (1, train.TrainDirection);
			Assert.AreEqual (41400, train.NextStationID);
			Assert.AreEqual (30269, train.NextStopID);
			Assert.AreEqual ("Roosevelt", train.NextStationName);
			Assert.AreEqual (new DateTime(2013,06,10,14,58,48), train.PredicationGeneratedTime);
			Assert.AreEqual (new DateTime(2013,06,10,14,59,48), train.PredicatedArrival);
			Assert.AreEqual (true, train.IsApproaching);
			Assert.AreEqual (false, train.IsDelayed);
			Assert.AreEqual ("", train.Flags);
			Assert.AreEqual (41.86579m, train.TrainLatitude);
			Assert.AreEqual (-87.62736m, train.TrainLongitude);
			Assert.AreEqual (358, train.HeadingDegrees);
		}
	}
}

