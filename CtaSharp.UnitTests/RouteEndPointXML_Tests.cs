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
using CtaSharp.Enums;
using CtaSharp.Shared.Interfaces;

namespace CtaSharp.UnitTests
{

	[TestFixture]
	public class RouteEndPointXML_Tests
	{
//const string XMLData = 
		private IDataSource CreateDataSource()
		{
			var mock = new Mock<IDataSource> ();

			mock.Setup (datasource => datasource.Execute ()).Returns (TestHelper.RouteDataString);

			return mock.Object;
		}

		[Test]
		public void Get()
		{
			var dataSource = CreateDataSource ();
			var converter = new XMLToRouteConverter ();
			var endpoint = new RouteEndPoint ("apikey", converter, dataSource);

			var routes = endpoint.Get (new RouteParameters () { Route = EnumTrainRoute.Red });

			Assert.AreEqual (1, routes.Count ());
		}

		[Test]
		public async void GetAsync()
		{
			var dataSource = CreateDataSource ();
			var converter = new XMLToRouteConverter ();
			var endpoint = new RouteEndPoint ("apikey", converter, dataSource);

			var task = endpoint.GetAsync (new RouteParameters () { Route = EnumTrainRoute.Red });

			Assert.NotNull (task);

			var routes = await task; 

			Assert.AreEqual (1, routes.Count ());
		}
	}
}

