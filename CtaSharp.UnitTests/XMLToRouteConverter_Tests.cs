using System;
using NUnit;
using NUnit.Framework;
using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.Parameters;
using CtaSharp.Models;
using System.Linq;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	public class XMLToRouteConverter_Tests
	{
		const string XMLData = 
@"<ctatt>
	<route name=""red"">
	    <train>
	      <rn>804</rn>
	      <destSt>30173</destSt>
	      <destNm>Howard</destNm>
	      <trDr>1</trDr>
	      <nextStaId>41400</nextStaId>
	      <nextStpId>30269</nextStpId>
	      <nextStaNm>Roosevelt</nextStaNm>
	      <prdt>20130610 14:58:48</prdt>
	      <arrT>20130610 14:59:48</arrT>
	      <isApp>1</isApp>
	      <isDly>0</isDly>
	      <flags />
	      <lat>41.86579</lat>
	      <lon>-87.62736</lon>
	      <heading>358</heading>
	    </train>
	</route>
</ctatt>";

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullXmlDataString()
		{
			IXmlConverter<Route> converter = new XMLToRouteConverter ();
			converter.Convert (null, "parentNode");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullParentNodeString()
		{
			IXmlConverter<Route> converter = new XMLToRouteConverter ();
			converter.Convert (XMLData, null);
		}

		[Test]
		public void BasicConversion()
		{
			IXmlConverter<Route> converter = new XMLToRouteConverter ();
			var result = converter.Convert (XMLData, "route").First();

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

