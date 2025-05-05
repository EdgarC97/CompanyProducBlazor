using CompanyProductBlazor.Helpers;
using CompanyProductBlazor.Models;
using CompanyProductBlazor.Services.Interfaces;

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

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _httpClient.PostAsJsonAsync<Product>(ApiEndpoint, product);
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            return await _httpClient.PutAsJsonAsync<Product>($"{ApiEndpoint}/{id}", product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _httpClient.DeleteAsync($"{ApiEndpoint}/{id}");
        }
    }
}