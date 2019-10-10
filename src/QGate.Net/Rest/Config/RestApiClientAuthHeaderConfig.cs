namespace QGate.Net.Rest.Config
{
    public class RestApiClientAuthHeaderConfig
    {
        public string HeaderName { get; set; } = "X-Api-Key";
        public string Secret { get; set; }
    }
}
