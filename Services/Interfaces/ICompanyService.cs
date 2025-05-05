using CompanyProductBlazor.Models;
using CompanyProductBlazor.Models.DTOs;

namespace CompanyProductBlazor.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(CompanyCreateDto company);
        Task UpdateCompanyAsync(int id, Company company);
        Task DeleteCompanyAsync(int id);
    }
}