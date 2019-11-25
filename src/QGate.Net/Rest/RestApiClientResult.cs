using System.Net.Http;

namespace QGate.Net.Rest
{
    public class RestApiClientResult<TResult>
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public TResult Data { get; set; }

        public bool IsSuccess
        {
            get
            {
                return HttpResponseMessage != null && HttpResponseMessage.IsSuccessStatusCode;
            }
        }

        /// <summary>
        /// Gets error message if exists
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetErrorMessageAsync()
        {
            if ((HttpResponseMessage?.IsSuccessStatusCode).GetValueOrDefault() || HttpResponseMessage.Content == null)
            {
                return null;
            }

            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
