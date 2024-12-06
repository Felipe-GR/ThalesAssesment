using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using ThalesAssesment.Model.Helpers.Interfaces;

namespace ThalesAssesment.Model.Helpers
{
    public class HttpHelper : IHttpHelper
    {
        private HttpClient _httpClient;
        private ILogger<HttpHelper> _logger;
        public HttpHelper(HttpClient httpClient, ILogger<HttpHelper> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{url} Exception: {ex.Message}");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest content)
        {
            var response = await _httpClient.PostAsJsonAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest content)
        {
            var response = await _httpClient.PutAsJsonAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
