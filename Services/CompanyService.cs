using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CompanyProductBlazor.Models;
using CompanyProductBlazor.Services.Interfaces;

namespace CompanyProductBlazor.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            var response = await _httpClient.GetAsync("api/companies");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Company>>(_options);
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/companies/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Company>(_options);
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            var content = new StringContent(JsonSerializer.Serialize(company), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/companies", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Company>(_options);
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company company)
        {
            var content = new StringContent(JsonSerializer.Serialize(company), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/companies/{id}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Company>(_options);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/companies/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}