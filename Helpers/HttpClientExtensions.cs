using System.Net.Http.Json;
using System.Text.Json;

namespace CompanyProductBlazor.Helpers
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<T> GetFromJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(JsonOptions)
                ?? throw new InvalidOperationException("No se pudo deserializar la respuesta");
        }

        public static async Task<T> PostAsJsonAsync<T>(this HttpClient httpClient, string url, object data)
        {
            var response = await httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(JsonOptions)
                ?? throw new InvalidOperationException("No se pudo deserializar la respuesta");
        }

        public static async Task<T> PutAsJsonAsync<T>(this HttpClient httpClient, string url, object data)
        {
            var response = await httpClient.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(JsonOptions)
                ?? throw new InvalidOperationException("No se pudo deserializar la respuesta");
        }

        public static async Task DeleteAsync(this HttpClient httpClient, string url)
        {
            var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}