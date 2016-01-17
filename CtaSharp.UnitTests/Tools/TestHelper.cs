using System;

namespace CtaSharp.UnitTests
{
	public class TestHelper
	{
		public const string ETADataString =
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

		public const string RouteDataString =
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
		
		public const string ArrivalsDataString =
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

	}
}

