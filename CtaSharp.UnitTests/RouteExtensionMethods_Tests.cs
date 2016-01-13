using System;
using System.Linq;
using NUnit;
using NUnit.Framework;
using Moq;
using CtaSharp.Extension;
using CtaSharp.EndPoint;
using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.Enums;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	public class RouteExtensionMethods_Tests
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
		//Ensure that the dependency falls through to the models
		public void DependencyPassthough()
		{
			var dataSource = CreateDataSource ();
			var xmlConverter = new XMLToRouteConverter ();
			
			RouteEndPointXML endpoint = new RouteEndPointXML ("key", xmlConverter, dataSource);
			var result = endpoint.Get (new CtaSharp.Parameters.RouteParameters () { Route = EnumTrainRoute.Red }).First();

			Assert.AreEqual (endpoint, result.EndPoint);
		}

		[Test]
		public void Refresh()
		{
			var dataSource = CreateDataSource ();
			var xmlConverter = new XMLToRouteConverter ();

			RouteEndPointXML endpoint = new RouteEndPointXML ("key", xmlConverter, dataSource);
			var result = endpoint.Get (new CtaSharp.Parameters.RouteParameters () { Route = EnumTrainRoute.Red }).First();

			var OriginalUpdateTime = result.UpdatedTime;

			result.Refresh ();

			var UpdatedUpdateTime = result.UpdatedTime;

			Assert.AreNotEqual (OriginalUpdateTime, UpdatedUpdateTime);
		}
	}
}

