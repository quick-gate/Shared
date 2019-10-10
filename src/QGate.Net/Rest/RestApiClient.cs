using Newtonsoft.Json;
using QGate.Net.Exceptions;
using QGate.Net.Http;
using QGate.Net.Rest.Config;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QGate.Net.Rest
{
    public class RestApiClient : IRestApiClient
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly RestApiClientConfig _config;
        public RestApiClient()
        {
            InitHttpClientFactory();
        }

        public RestApiClient(RestApiClientConfig config)
        {
            _config = config;
            InitHttpClientFactory();
        }

        private void InitHttpClientFactory()
        {
            _httpClientFactory = new HttpClientFactory();
        }

        public async Task<RestApiClientResult<TResult>> DeleteAsync<TResult>(string url)
        {
            var httpClient = GetHttpClient();
            var response = await httpClient.DeleteAsync(url);
            return await GetResult<TResult>(response);
        }

        public async Task<RestApiClientResult<TResult>> GetAsync<TResult>(string url)
        {
            var httpClient = GetHttpClient();
            var response = await httpClient.GetAsync(url);
            return await GetResult<TResult>(response);
        }

        public Task<RestApiClientResult<TResult>> PostAsync<TResult>(string url, object data)
        {
            return PostAsync<TResult>(url, data, null);
        }

        public Task<RestApiClientResult<TResult>> PostAsync<TResult>(string url, object data, RestApiCallConfig config)
        {
            return PostOrPutAsync<TResult>(url, data, true);
        }

        public Task<RestApiClientResult<object>> PostAsync(string url, object data, RestApiCallConfig config)
        {
            throw new NotImplementedException();
        }

        public Task<RestApiClientResult<object>> PostAsync(string url, object data)
        {
            throw new NotImplementedException();
        }

        public Task<RestApiClientResult<TResult>> PutAsync<TResult>(string url, object data)
        {
            throw new NotImplementedException();
        }

        public Task<RestApiClientResult<object>> PutAsync(string url, object data)
        {
            throw new NotImplementedException();
        }

        private async Task<RestApiClientResult<TResult>> PostOrPutAsync<TResult>(string url, object data, bool post)
        {

            //There are possibility to overload this method with content type parameter

            var serializedObject = JsonConvert.SerializeObject(data);

            HttpContent content = data is HttpContent ?
                data as HttpContent :
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, ContentType.ApplicationJson);

            var httpClient = GetHttpClient();
            var response = post ?
                await httpClient.PostAsync(url, content) :
                await httpClient.PutAsync(url, content);

            return await GetResult<TResult>(response);
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = _httpClientFactory.Get();
            if(string.IsNullOrWhiteSpace(_config?.AuthConfig?.AuthHeaderConfig?.Secret))
            {
                return httpClient;
            }

            if(httpClient.DefaultRequestHeaders.Contains(_config.AuthConfig.AuthHeaderConfig.HeaderName))
            {
                return httpClient;
            }

            httpClient.DefaultRequestHeaders.Add(
                _config.AuthConfig.AuthHeaderConfig.HeaderName,
                _config.AuthConfig.AuthHeaderConfig.Secret);

            return httpClient;

        }

        private async Task<RestApiClientResult<TResult>> GetResult<TResult>(HttpResponseMessage httpResponseMessage)
        {
            var result = new RestApiClientResult<TResult>
            {
                HttpResponseMessage = httpResponseMessage
            };

            if (!IsSuccessfulCall(httpResponseMessage))
            {
                return result;
            }

            result.Data = await GetResultDataAsync<TResult>(httpResponseMessage);

            return result;
        }

        private static Task<TResult> GetResultDataAsync<TResult>(HttpResponseMessage httpResponseMessage)
        {
            object data = null;

            var resultType = typeof(TResult);

            if (resultType == typeof(Stream))
            {
                data = httpResponseMessage.Content.ReadAsStreamAsync();
                return (Task<TResult>)data;
            }

            if (resultType == typeof(byte[]))
            {
                data = httpResponseMessage.Content.ReadAsByteArrayAsync();
                return (Task<TResult>)data;
            }

            data = httpResponseMessage.Content.ReadAsStringAsync().Result;

            if (typeof(TResult) == typeof(string))
            {
                return (Task<TResult>)data;
            }

            try
            {
                return Task.Run(() => JsonConvert.DeserializeObject<TResult>(Convert.ToString(data), new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore }));
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to convert result from raw response to typed result. Raw result is: \"{Convert.ToString(data)}\". See inner exception from details.", e);
            }
        }

        

        private void CheckResult<TResult>(RestApiClientResult<TResult> result)
        {
            if (result.HttpResponseMessage != null)
            {
                CheckResult(result.HttpResponseMessage);
            }
        }

        private void CheckResult(HttpResponseMessage httpResponseMessage)
        {
            if (!IsSuccessfulCall(httpResponseMessage))
            {
                throw new UnsuccessfulRequestException($"Http operation failed {httpResponseMessage.StatusCode}, Result: {httpResponseMessage.Content.ReadAsStringAsync().Result}", httpResponseMessage.StatusCode);
            }
        }

        private bool IsSuccessfulCall(HttpResponseMessage httpResponseMessage)
        {
            //TODO HttpClient automatically redirecting when 302 is returned. 302 Is not sucessful code
            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}
