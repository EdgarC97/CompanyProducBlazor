using CompanyProductBlazor.Models;
using CompanyProductBlazor.Models.DTOs;
using CompanyProductBlazor.Services.Interfaces;
using System.Net.Http.Json;

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

        public async Task<Company> CreateCompanyAsync(CompanyCreateDto company)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiEndpoint, company);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Company>();
        }

        public async Task UpdateCompanyAsync(int id, Company company)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiEndpoint}/{id}", company);
            response.EnsureSuccessStatusCode(); 
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiEndpoint}/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new HttpRequestException("La compañía tiene productos asociados y no puede ser eliminada.", null, response.StatusCode);
            }

            response.EnsureSuccessStatusCode();
        }

    }
}
