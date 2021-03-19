using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace API
{
    public abstract class RestAPIWrapper
    {
        protected string _WebServiceUrl;
        protected HttpClient _Client;
        protected Dictionary<string, string> _Params;

        public RestAPIWrapper(HttpClient client, string url)
        {
            _Client = client;
            _WebServiceUrl = url;
        }

        protected virtual string GetUrl()
        {
            Uri newUrl;

            if (_Params == null)
                newUrl = new Uri(_WebServiceUrl);
            else
                newUrl = new Uri(QueryHelpers.AddQueryString(_WebServiceUrl, _Params));

            return newUrl.ToString();
        }

    }
}
