using System;
using System.Net.Http;

namespace QGate.Net.Http
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient Get()
        {
            return new HttpClient();
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
