using System.Net.Http;

namespace QGate.Net.Http
{
    public interface IHttpClientFactory
    {
        HttpClient Get();

        HttpClient Get(HttpMessageHandler handler);
    }
}
