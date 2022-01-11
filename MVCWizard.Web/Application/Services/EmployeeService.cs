using MVCWizard.Web.Application.Contracts;
using MVCWizard.Web.Models;
using System.Text.Json;

namespace MVCWizard.Web.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }


        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var httpResponseMessage =await _httpClient.GetAsync("api/Employee");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var serOpt = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var AllEmps = JsonSerializer.Deserialize<List<EmployeeDto>>(contentStream, serOpt);
                return AllEmps is null ? new List<EmployeeDto>() : AllEmps;

            }
            return new List<EmployeeDto>();
        }

        public async Task<EmployeeDto> GetEmployeeByIDAsync(int Id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"api/Employee/{Id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var serOpt = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var Emp = JsonSerializer.Deserialize<EmployeeDto>(contentStream, serOpt);
                return Emp is null ? new EmployeeDto() : Emp;

            }
            return new EmployeeDto();
        }

        public async Task<int> CreateAsync(EmployeeDto emp)
        {
            var httpResponseMessage =await _httpClient.PostAsJsonAsync("api/Employee",emp);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var serOpt = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var EmpId = JsonSerializer.Deserialize<int>(contentStream, serOpt);
                return EmpId;
            }
            return -1;
        }

        public async Task<int> UpdateAsync(EmployeeDto emp)
        {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync("api/Employee", emp);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var serOpt = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var EmpId = JsonSerializer.Deserialize<int>(contentStream, serOpt);
                return EmpId;
            }
            return -1;
        }


    }
}
