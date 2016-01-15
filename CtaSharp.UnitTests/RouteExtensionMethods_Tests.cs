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

		private IDataSource CreateDataSource()
		{
			var mock = new Mock<IDataSource> ();

			mock.Setup (datasource => datasource.Execute ()).Returns (TestHelper.RouteDataString);

			return mock.Object;
		}

		[Test]
		//Ensure that the dependency falls through to the models
		public void DependencyPassthough()
		{
			var dataSource = CreateDataSource ();
			var xmlConverter = new XMLToRouteConverter ();
			
			RouteEndPoint endpoint = new RouteEndPoint ("key", xmlConverter, dataSource);
			var result = endpoint.Get (new CtaSharp.Parameters.RouteParameters () { Route = EnumTrainRoute.Red }).First();

			Assert.AreEqual (endpoint, result.EndPoint);
		}

		[Test]
		public void Refresh()
		{
			var dataSource = CreateDataSource ();
			var xmlConverter = new XMLToRouteConverter ();

			RouteEndPoint endpoint = new RouteEndPoint ("key", xmlConverter, dataSource);
			var result = endpoint.Get (new CtaSharp.Parameters.RouteParameters () { Route = EnumTrainRoute.Red }).First();

			var OriginalUpdateTime = result.UpdatedTime;

			var isSuccessful = result.TryRefresh ();

			Assert.AreEqual (true, isSuccessful);

			var UpdatedUpdateTime = result.UpdatedTime;

			Assert.AreNotEqual (OriginalUpdateTime, UpdatedUpdateTime);
		}
	}
}

