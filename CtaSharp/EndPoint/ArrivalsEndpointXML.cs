using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using CtaSharp.Models;
using CtaSharp.Parameters;
using CtaSharp.EndPoint.DataSource;

namespace CtaSharp.EndPoint
{
	public class ArrivalsEndpointXML : IEndpoint<ETA, ArrivalsParameters>
	{		
		string _APIKey { get; }

		public ArrivalsEndpointXML(string APIKey)
		{
			this._APIKey = APIKey;
		}

		public IEnumerable<ETA> Get (ArrivalsParameters parameters)
		{
			ArrivalsDataSource dataSource = new ArrivalsDataSource ();
			dataSource.AddParameter ("key", this._APIKey);

			return null;
		}

		public async Task<System.Collections.Generic.IEnumerable<ETA>> GetAsync (ArrivalsParameters parameters)
		{
			throw new NotImplementedException ();
		}
	}
}

