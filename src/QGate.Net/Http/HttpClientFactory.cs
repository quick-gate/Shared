using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;

namespace QGate.Net.Http
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private const string DefaultContextName = "Internal_DefaultContext";
        private static IDictionary<string, Lazy<HttpClient>> _httpClientDictionary = new ConcurrentDictionary<string, Lazy<HttpClient>>();
        public HttpClient Get()
        {
            return FindOrCreateHttpClient(DefaultContextName);
        }

        public HttpClient Get(HttpMessageHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            var contextName = string.Concat("Handler_", handler.GetHashCode());
            return FindOrCreateHttpClient(contextName, handler);
        }

        public HttpClient Get(string contextName)
        {
            return FindOrCreateHttpClient(contextName);
        }

        private HttpClient FindOrCreateHttpClient(string contextName, HttpMessageHandler handler = null)
        {
            if (_httpClientDictionary.TryGetValue(contextName, out Lazy<HttpClient> httpClientLazy))
            {
                return httpClientLazy.Value;
            }

            httpClientLazy = new Lazy<HttpClient>(() => handler == null ? new HttpClient() : new HttpClient(handler));
            _httpClientDictionary.Add(contextName, httpClientLazy);
            return httpClientLazy.Value;
        }
    }
}
