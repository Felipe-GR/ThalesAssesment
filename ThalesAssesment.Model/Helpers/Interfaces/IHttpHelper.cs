namespace ThalesAssesment.Model.Helpers.Interfaces
{
    public interface IHttpHelper
    {
        Task<T> GetAsync<T>(string url);

        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest content);

        Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest content);

        Task DeleteAsync(string url);
    }
}
