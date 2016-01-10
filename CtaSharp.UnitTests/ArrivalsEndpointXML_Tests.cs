using System;
using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.EndPoint;
using NUnit.Framework;
using NUnit;
using Moq;
using System.Linq;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	internal class ArrivalsEndpointXML_Tests
	{
		const string XMLDta = 
@"<ctatt>
  <tmst>20110618 23:26:50</tmst>
  <errCd>0</errCd>
  <errNm/>
  <eta>
    <staId>40360</staId>
    <stpId>30070</stpId>
    <staNm>Southport</staNm>
    <stpDe>Service toward Kimball</stpDe>
    <rn>419</rn>
    <rt>Brn</rt>
    <destSt>30249</destSt>
    <destNm>Kimball</destNm>
    <trDr>1</trDr>
    <prdt>20110618 23:26:12</prdt>
    <arrT>20110618 23:28:12</arrT>
    <isApp>0</isApp>
    <isSch>0</isSch>
    <isDly>0</isDly>
    <isFlt>0</isFlt>
    <flags/>
    <lat>41.97776</lat>
    <lon>-87.77567</lon>
    <heading> 299</heading>
  </eta>
</ctatt>";

		private IDataSource CreateArrivalsDatasource()
		{
			var mock = new Mock<IDataSource> ();
			mock.Setup (datasource => datasource.Execute ()).Returns (XMLDta);
			return mock.Object;
		}

		[Test]
		public void Get()
		{
			var dataSource = CreateArrivalsDatasource ();
			var converter = new XMLToETAConverter ();

			var endpoint = new ArrivalsEndpointXML ("APIKey", converter, dataSource);

			var result = endpoint.Get (new ArrivalsParameters() { });

			Assert.AreEqual (1, result.Count ());
		}
	}
}

