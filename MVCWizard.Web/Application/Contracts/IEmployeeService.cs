using MVCWizard.Web.Models;

namespace MVCWizard.Web.Application.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIDAsync(int Id);
        Task<int> CreateAsync(EmployeeDto emp);
        Task<int> UpdateAsync(EmployeeDto emp);

    }
}
