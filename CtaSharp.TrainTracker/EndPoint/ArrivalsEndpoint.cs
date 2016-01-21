using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using CtaSharp.Models;
using CtaSharp.Parameters;
using CtaSharp.EndPoint.DataSource;
using CtaSharp.EndPoint.Converters;
using CtaSharp.Tools.XML;
using CtaSharp.Shared.Interfaces;

namespace CtaSharp.EndPoint
{
	internal class ArrivalsEndpoint : IEndpoint<ETA, ArrivalsParameters>
	{		
		string _APIKey { get; }
		IDataSource _dataSource { get; }
		IConverter<ETA> _converter { get; }

		internal ArrivalsEndpoint(string APIKey)
		{
			this._dataSource = new ArrivalsDataSource ();
			this._converter = new XMLToETAConverter ();
            this._APIKey = APIKey;
		}

		internal ArrivalsEndpoint(string APIKey, IConverter<ETA> converter, IDataSource dataSource)
		{
			this._dataSource = dataSource;
			this._converter = converter;
			this._APIKey = APIKey;
		}

		public IEnumerable<ETA> Get (ArrivalsParameters parameters)
		{
			_dataSource.AddParameter ("key", this._APIKey);
			_applyParameters (_dataSource, parameters);

			var data = _dataSource.Execute ();
			return this._converter.Convert (data, "ctatt");
		}
			
		//Todo: Essentially a switch case. Maybe worth burying it deeper in the code somewhere
		private void _applyParameters(IDataSource dataSource, ArrivalsParameters parameters)
		{
			if (parameters.NumericStationIdentifier.HasValue)
			{
				_applyParameter(dataSource, "mapid", parameters.NumericStationIdentifier);
			}
			if (parameters.NumericStopIdentifier.HasValue)
			{
				_applyParameter(dataSource, "stpid", parameters.NumericStopIdentifier);
			}
			if (parameters.MaximumResults.HasValue) {
				_applyParameter(dataSource, "max", parameters.MaximumResults);
			}
			if (string.IsNullOrEmpty (parameters.RouteCode) == false)
			{
				_applyParameter(dataSource, "rt", parameters.RouteCode);
			}
		}

		private void _applyParameter<T>(IDataSource dataSource, string name, T value)
		{
			if (string.IsNullOrEmpty (name) || dataSource == null || value == null) {
				throw new ArgumentNullException ();
			}

			dataSource.AddParameter (name, value.ToString ());
		}


		public async Task<System.Collections.Generic.IEnumerable<ETA>> GetAsync (ArrivalsParameters parameters)
		{
			return await Task.Run (() => {
				return this.Get(parameters);
			});
		}
	}
}

