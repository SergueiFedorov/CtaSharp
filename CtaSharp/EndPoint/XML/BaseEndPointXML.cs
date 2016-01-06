using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.EndPoint.XML
{
    internal abstract class BaseEndPointXML
    {
        protected Uri uri { get; }
        protected WebClient _client { get; }
        protected string APIKey { get; }

        protected BaseEndPointXML(string APIKey, string URIString)
        {
            this.uri = new Uri(URIString);
            this._client = new WebClient();

            this.APIKey = APIKey;
        }
    }
}
