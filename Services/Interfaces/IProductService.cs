using CompanyProductBlazor.Models;

namespace CompanyProductBlazor.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetProductsByCompanyIdAsync(int companyId);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
    }
}