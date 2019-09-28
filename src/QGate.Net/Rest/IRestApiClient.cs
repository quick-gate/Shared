using System.Threading.Tasks;

namespace QGate.Net.Rest
{
    /// <summary>
    /// REST API Client
    /// </summary>
    public interface IRestApiClient
    {
        /// <summary>
        /// HTTP GET method wrapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<RestApiClientResult<TResult>> GetAsync<TResult>(string url);

        /// <summary>
        /// HTTP POST method wrapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RestApiClientResult<TResult>> PostAsync<TResult>(string url, object data);

        /// <summary>
        /// HTTP POST method wrapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name=""></param>
        /// <param name="config"></param>
        /// <returns></returns>
        Task<RestApiClientResult<TResult>> PostAsync<TResult>(string url, object data, RestApiCallConfig config);

        /// <summary>
        /// HTTP POST method wrapper
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        Task<RestApiClientResult<object>> PostAsync(string url, object data, RestApiCallConfig config);

        /// <summary>
        /// HTTP POST method wrapper
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RestApiClientResult<object>> PostAsync(string url, object data);

        /// <summary>
        /// HTTP PUT method wrapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RestApiClientResult<TResult>> PutAsync<TResult>(string url, object data);

        /// <summary>
        /// HTTP PUT method wrapper
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RestApiClientResult<object>> PutAsync(string url, object data);

        /// <summary>
        /// HTTP Delete method wrapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<RestApiClientResult<TResult>> DeleteAsync<TResult>(string url);
    }
}
