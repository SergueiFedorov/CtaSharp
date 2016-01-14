using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CtaSharp;
using CtaSharp.Extension;
using CtaSharp.Parameters;
using CtaSharp.EndPoint;
using CtaSharp.EndPoint.DataSource;
using Moq;

namespace CtaSharp.UnitTests
{
    [TestFixture]
    class ETAExtensionMethods_Tests
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
            var dataSourceMock = new Mock<IDataSource>();
            dataSourceMock.Setup(dataSource => dataSource.Execute())
                .Returns(() => XMLData);

            return dataSourceMock.Object;
        }

        [Test]
        public void Refresh()
        {
            var dataSource = MockETADataSource(XMLData);
            //ETAEndPointXML endpoint = new ETAEndPointXML("key", 
        }
    }
}
