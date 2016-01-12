using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using CtaSharp.Models;
using CtaSharp.Parameters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.EndPoint.Converters;
using CtaSharp.Tools.XML;

namespace CtaSharp.EndPoint
{
	internal class ArrivalsEndpointXML : IEndpoint<ETA, ArrivalsParameters>
	{		
		string _APIKey { get; }
		IDataSource _dataSource { get; }
		IXmlConverter<ETA> _converter { get; }

		internal ArrivalsEndpointXML(string APIKey)
		{
			this._dataSource = new ArrivalsDataSource ();
			this._converter = new XMLToETAConverter ();
            this._APIKey = APIKey;
		}

		internal ArrivalsEndpointXML(string APIKey, IXmlConverter<ETA> converter, IDataSource dataSource)
		{
			this._dataSource = dataSource;
			this._converter = converter;
			this._APIKey = APIKey;
		}

		public IEnumerable<ETA> Get (ArrivalsParameters parameters)
		{
			_dataSource.AddParameter ("key", this._APIKey);

			ApplyParameters (_dataSource, parameters);

			var data = _dataSource.Execute ();

			return this._converter.Convert (data, "ctatt");
		}

		private void ApplyParameters(IDataSource dataSource, ArrivalsParameters parameters)
		{
			if (parameters.NumericStationIdentifier.HasValue)
			{
				dataSource.AddParameter ("mapid", parameters.NumericStationIdentifier.ToString());
			}
			if (parameters.NumericStopIdentifier.HasValue)
			{
				dataSource.AddParameter ("stpid", parameters.NumericStopIdentifier.ToString());
			}
			if (parameters.MaximumResults.HasValue) {
				dataSource.AddParameter ("max", parameters.MaximumResults.ToString());
			}
			if (string.IsNullOrEmpty (parameters.RouteCode) == false)
			{
				dataSource.AddParameter ("rt", parameters.RouteCode);
			}
		}

		public async Task<System.Collections.Generic.IEnumerable<ETA>> GetAsync (ArrivalsParameters parameters)
		{
			return await Task.Run (() => {
				return this.Get(parameters);
			});
		}
	}
}

