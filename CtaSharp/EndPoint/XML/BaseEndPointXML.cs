using System;
using System.Net;

namespace CtaSharp.EndPoint.XML
{
    internal abstract class BaseEndPointXML
    {
        private Uri _uri { get; }
        private WebClient _client { get; }
        private string _APIKey { get; }

        protected BaseEndPointXML(string APIKey, string URIString)
        {
            this._uri = new Uri(URIString);
            this._client = new WebClient();

            this._APIKey = APIKey;

            AddParameter("key", this._APIKey);
        }

        protected void AddParameter(string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }

            this._client.QueryString.Add(name, value);
        }

        protected void ClearParameters()
        {
            this._client.QueryString.Clear();
            AddParameter("key", this._APIKey);
        }

        protected string DownloadContent()
        {
            return this._client.DownloadString(_uri);
        }
    }
}
