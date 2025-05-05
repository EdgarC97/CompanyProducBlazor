using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CompanyProductBlazor.Models;
using CompanyProductBlazor.Services.Interfaces;

namespace CompanyProductBlazor.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Product>>(_options);
        }

        public async Task<IEnumerable<Product>> GetProductsByCompanyIdAsync(int companyId)
        {
            var response = await _httpClient.GetAsync($"api/companies/{companyId}/products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Product>>(_options);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>(_options);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/products", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>(_options);
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/products/{id}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>(_options);
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}