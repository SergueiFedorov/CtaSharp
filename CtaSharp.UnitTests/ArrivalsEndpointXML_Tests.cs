using System;
using CtaSharp.EndPoint.Converters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.EndPoint;
using NUnit.Framework;
using NUnit;
using Moq;
using System.Linq;
using CtaSharp.Shared.Interfaces;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	internal class ArrivalsEndpointXML_Tests
	{

		private IDataSource CreateArrivalsDatasource()
		{
			var mock = new Mock<IDataSource> ();
			mock.Setup (datasource => datasource.Execute ()).Returns (TestHelper.ArrivalsDataString);
			return mock.Object;
		}

		[Test]
		public void Get()
		{
			var dataSource = CreateArrivalsDatasource ();
			var converter = new XMLToETAConverter ();

			var endpoint = new ArrivalsEndpoint ("APIKey", converter, dataSource);

			var result = endpoint.Get (new ArrivalsParameters() { });

			Assert.AreEqual (1, result.Count ());
		}
	}
}

