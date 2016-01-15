using NUnit.Framework;
using CtaSharp.EndPoint;
using CtaSharp.Models;
using CtaSharp.Parameters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.EndPoint.Converters;
using System;
using System.Linq;
using Moq;

namespace CtaSharp.UnitTests
{
	[TestFixture]
	public class Test
	{
		const string XMLData = 
@"<ctatt>
  <eta>
    <staId>40010</staId>
    <stpId>30001</stpId>
    <staNm>Austin</staNm>
    <stpDe>Austin to O'Hare</stpDe>
    <rn>123</rn>
    <rt>Blue Line</rt>
    <destSt>30171</destSt>
    <destNm>O'Hare</destNm>
    <trDr>1</trDr>
    <prdt>20130515 14:10:23</prdt>
    <arrT>20130515 14:11:23</arrT>
    <isApp>1</isApp>
    <isSch>0</isSch>
    <isDly>0</isDly>
    <isFlt>0</isFlt>
    <flags/> 
  </eta>
</ctatt>";


		private IDataSource MockETADataSource(string data)
		{
			var dataSourceMock = new Mock<IDataSource> ();
			dataSourceMock.Setup(dataSource => dataSource.Execute())
				.Returns(() => XMLData);

			return dataSourceMock.Object;
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InjectConverterAndDataSource_CheckNullArguementNoDataSource()
		{
			var dataSourceMock = new Mock<IDataSource> ();
			new ETAEndPoint ("", null, dataSourceMock.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InjectConverterAndDataSource_CheckNullArguementNoConverter()
		{
			var converterMock = new Mock<IXmlConverter<ETA>> ();
			new ETAEndPoint ("", converterMock.Object, null);
		}

		[Test]
		public void Get()
		{
			var dataSourceMock = MockETADataSource (XMLData);
			var xmlConverter = new XMLToETAConverter ();

			var endPoint = new ETAEndPoint ("key", xmlConverter, dataSourceMock);
			var result = endPoint.Get (new ETAParameters () { RunNumber = 123 });

			Assert.AreEqual (1, result.Count ());
			Assert.AreEqual (123, result.First ().RunNumber);
		}

		[Test]
		public async void GetAsync()
		{
			var dataSourceMock = MockETADataSource (XMLData);
			var xmlConverter = new XMLToETAConverter ();

			var endPoint = new ETAEndPoint ("key", xmlConverter, dataSourceMock);
			var task = endPoint.GetAsync (new ETAParameters () { RunNumber = 123 });

			Assert.NotNull (task);

			var result = await task;

			Assert.AreEqual (1, result.Count ());
			Assert.AreEqual (123, result.First ().RunNumber);
		}

	}
}

