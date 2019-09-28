using System;
using System.Net.Http;

namespace QGate.Net.Http
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private static readonly Lazy<HttpClient> _httpClientLazy = new Lazy<HttpClient>(() => new HttpClient());
        public HttpClient Get()
        {
            return _httpClientLazy.Value;
        }

        public HttpClient Get(HttpMessageHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return new HttpClient(handler);
        }
    }
}
