using CompanyProductBlazor.Models;

namespace CompanyProductBlazor.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(int id, Company company);
        Task DeleteCompanyAsync(int id);
    }
}