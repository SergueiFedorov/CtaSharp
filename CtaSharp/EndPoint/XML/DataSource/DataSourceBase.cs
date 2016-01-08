﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.EndPoint.XML.DataSource
{
    internal abstract class DataSourceBase
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
    }
}
