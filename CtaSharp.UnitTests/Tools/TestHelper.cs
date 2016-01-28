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

        public const string BusVehicleString =
@"<bustime-response>
    <vehicle>
	    <vid>1369</vid>
	    <tmstmp>20160121 21:26</tmstmp>
	    <lat>41.865718841552734</lat>
	    <lon>-87.7553244925834</lon>
	    <hdg>89</hdg>
	    <pid>4135</pid>
	    <rt>12</rt>
	    <des>15th/Indiana</des>
	    <pdist>5238</pdist>
	    <spd>0</spd>
	    <tablockid>12 -209</tablockid>
	    <tatripid>1074820</tatripid>
	    <zone/>
    </vehicle>
</bustime-response>";

        public const string BusRouteString =
@"<bustime-response>
    <route>
        <rt>1</rt>
        <rtnm>Bronzeville/Union Station</rtnm>
        <rtclr>#336633</rtclr>
    </route>
</bustime-response>";

        public const string TimeString =
@"<bustime-response>
    <tm>20160127 21:31:24</tm>
</bustime-response>";

        public const string BusDirectionString =
@"<bustime-response>
    <dir>Eastbound</dir>
    <dir>Westbound</dir>
</bustime-response>";

    }
}

