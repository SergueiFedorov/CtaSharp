using System;
using NUnit;
using NUnit.Framework;
using Moq;
using CtaSharp.EndPoint;
using CtaSharp.Parameters;
using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp;
using CtaSharp.Models;
using System.Linq;

namespace CtaSharp.UnitTests
{

	[TestFixture]
	public class RouteEndPointXML_Tests
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
		
		private IDataSource CreateDataSource()
		{
			var mock = new Mock<IDataSource> ();

			mock.Setup (datasource => datasource.Execute ()).Returns (XMLData);

			return mock.Object;
		}

		[Test]
		public void Get()
		{
			var dataSource = CreateDataSource ();
			var converter = new XMLToRouteConverter ();
			var endpoint = new RouteEndPointXML ("apikey", converter, dataSource);

			var routes = endpoint.Get (new RouteParameters () { });

			Assert.AreEqual (1, routes.Count ());
		}

		[Test]
		public async void GetAsync()
		{
			var dataSource = CreateDataSource ();
			var converter = new XMLToRouteConverter ();
			var endpoint = new RouteEndPointXML ("apikey", converter, dataSource);

			var task = endpoint.GetAsync (new RouteParameters () { });

			Assert.NotNull (task);

			var routes = await task; 

			Assert.AreEqual (1, routes.Count ());
		}
	}
}

