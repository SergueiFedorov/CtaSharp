using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.Shared
{
    public abstract class DataSourceBase
    {
        protected WebClient _client { get; }
        private string _Url { get; }

        protected DataSourceBase(string url)
        {
            this._Url = url;
            this._client = new WebClient();
        }

        protected string DownloadContent()
        {
            return _client.DownloadString(_Url);
        }

		public void AddParameter(string name, string value)
		{
			_client.QueryString.Add(name, value);
		}

        public void ClearParameters()
        {
            _client.QueryString.Clear();
        }

        public string Execute()
        {
            var result = DownloadContent();
            _client.QueryString.Clear();

            return result;
        }
    }
}
