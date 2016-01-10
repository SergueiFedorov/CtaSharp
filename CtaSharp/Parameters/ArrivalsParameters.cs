using System;

namespace CtaSharp
{
	public class ArrivalsParameters
	{
		private int? _NumericStationIdentifier { get; set; }
		public int? NumericStationIdentifier 
		{ 
			get {
				return _NumericStationIdentifier;
			}
			set {
				if (this.NumericStopIdentifier.HasValue) {
					throw new Exception ("Numeric stop identifyer has already been set");
				}

				this._NumericStationIdentifier = value;
			}
		}

		private int? _NumericStopIdentifier { get; set; }
		public int? NumericStopIdentifier 
		{ 
			get {
				return _NumericStopIdentifier;
			}
			set {
				if (this.NumericStationIdentifier.HasValue) {
					throw new Exception ("Numeric station identifyer has already been set");
				}

				this._NumericStopIdentifier = value;
			}
		}

		public int? MaximumResults { get; set; }
		public string RouteCode { get; set; }
	}
}

