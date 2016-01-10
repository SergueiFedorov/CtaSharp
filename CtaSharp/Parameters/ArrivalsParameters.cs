using System;

namespace CtaSharp
{
	public class ArrivalsParameters
	{
		public int NumericStationIdentifier { get; set; }
		public int NumericStopIdentifier { get; set; }
		public int? MaximumResults { get; set; }
		public string RouteCode { get; set; }
	}
}

