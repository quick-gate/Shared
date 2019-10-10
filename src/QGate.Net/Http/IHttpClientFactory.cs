using System.Net.Http;

namespace QGate.Net.Http
{
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Gets new or existing instance of HttpClient
        /// </summary>
        /// <returns></returns>
        HttpClient Get();
        /// <summary>
        /// Gets new or existing instance of HttpClient for given context
        /// </summary>
        /// <param name="contextName">Determines context for which will be HttpClient reused</param>
        /// <returns></returns>
        HttpClient Get(string contextName);

        HttpClient Get(HttpMessageHandler handler);
    }
}
