using MVCWizard.Web.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MVCWizard.Web.Application.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployees();

    }
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }


        public async Task<List<EmployeeDto>> GetAllEmployees()
        {

            var httpResponseMessage = _httpClient.GetAsync("api/Employee");


            if (httpResponseMessage.Result.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Result.Content.ReadAsStreamAsync();
                var serOpt = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var AllEmps = JsonSerializer.Deserialize<List<EmployeeDto>>(contentStream, serOpt);
                return AllEmps is null ? new List<EmployeeDto>() : AllEmps;

            }
            return new List<EmployeeDto>();
        }
    }
}
