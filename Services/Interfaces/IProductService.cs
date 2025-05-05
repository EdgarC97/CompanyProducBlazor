using CompanyProductBlazor.Models;
using CompanyProductBlazor.Models.DTOs;

namespace CompanyProductBlazor.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetProductsByCompanyIdAsync(int companyId);
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(ProductCreateDto product);
        Task UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
    }
}
