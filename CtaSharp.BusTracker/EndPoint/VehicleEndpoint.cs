using CtaSharp.BusTracker.Models;
using CtaSharp.BusTracker.Parameters;
using CtaSharp.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CtaSharp.BusTracker.EndPoint
{
    internal class VehicleEndpoint : IEndpoint<Vehicle, VehicleParameters>
    {
		IDataSource _dataSource { get; }
		IConverter<Vehicle> _converter { get; }

		string _key { get; }

		public VehicleEndpoint(string key, IDataSource datasource, IConverter<Vehicle> converter)
		{
			this._dataSource = datasource;
			this._converter = converter;
			this._key = key;
		}

        public IEnumerable<Vehicle> Get(VehicleParameters parameters)
        {
			_dataSource.AddParameter ("key", _key);


			string xml = _dataSource.Execute ();
			return _converter.Convert (xml, " ");
        }

        public async Task<IEnumerable<Vehicle>> GetAsync(VehicleParameters parameters)
        {
			return await Task.Run (() => {
				return this.Get(parameters);
			});
        }
    }
}
