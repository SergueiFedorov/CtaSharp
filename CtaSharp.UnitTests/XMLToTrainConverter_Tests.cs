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
	public class XMLToTrainConverter_Tests
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
			IXmlConverter<Train> converter = new XMLToTrainConverter ();
			converter.Convert (null, "parentNode");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullParentNodeString()
		{
			IXmlConverter<Train> converter = new XMLToTrainConverter ();
			converter.Convert (XMLData, null);
		}

		[Test]
		public void BasicConversion()
		{
			IXmlConverter<Train> converter = new XMLToTrainConverter ();
			var result = converter.Convert (XMLData, "route").First();

			Assert.AreEqual (804, result.RunNumber);
			Assert.AreEqual (30173, result.DestinationStopNumber);
			Assert.AreEqual ("Howard", result.DestinationName);
			Assert.AreEqual (1, result.TrainDirection);
			Assert.AreEqual (41400, result.NextStationID);
			Assert.AreEqual (30269, result.NextStopID);
			Assert.AreEqual ("Roosevelt", result.NextStationName);
			Assert.AreEqual (new DateTime(2013,06,10,14,58,48), result.PredicationGeneratedTime);
			Assert.AreEqual (new DateTime(2013,06,10,14,59,48), result.PredicatedArrival);
			Assert.AreEqual (true, result.IsApproaching);
			Assert.AreEqual (false, result.IsDelayed);
			Assert.AreEqual ("", result.Flags);
			Assert.AreEqual (41.86579m, result.TrainLatitude);
			Assert.AreEqual (-87.62736m, result.TrainLongitude);
			Assert.AreEqual (358, result.HeadingDegrees);
		}
	}
}

