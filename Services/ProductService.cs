using CompanyProductBlazor.Models;
using CompanyProductBlazor.Models.DTOs;
using CompanyProductBlazor.Services.Interfaces;
using System.Net.Http.Json;

namespace CompanyProductBlazor.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private const string ApiEndpoint = "products";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>(ApiEndpoint);
        }

        public async Task<IEnumerable<Product>> GetProductsByCompanyIdAsync(int companyId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"companies/{companyId}/products");
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"{ApiEndpoint}/{id}");
        }

        public async Task CreateProductAsync(ProductCreateDto productDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"companies/{productDto.CompanyId}/products", productDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiEndpoint}/{id}", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
