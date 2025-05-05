using CompanyProductBlazor.Helpers;
using CompanyProductBlazor.Models;
using CompanyProductBlazor.Services.Interfaces;

namespace CompanyProductBlazor.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;
        private const string ApiEndpoint = "companies";

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Company>>(ApiEndpoint);
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Company>($"{ApiEndpoint}/{id}");
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            return await _httpClient.PostAsJsonAsync<Company>(ApiEndpoint, company);
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company company)
        {
            return await _httpClient.PutAsJsonAsync<Company>($"{ApiEndpoint}/{id}", company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync($"{ApiEndpoint}/{id}");
        }
    }
}