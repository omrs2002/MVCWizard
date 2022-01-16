using MVCWizard.Data.Models;

namespace MVCWizard.Api.Application.Contracts
{
    public interface IEmployeeRepository
    {

        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIDAsync(int Id);
        Task<int> CreateAsync(Employee emp);
        Task<int> UpdateAsync(Employee emp);
        Task<bool> DeleteAsync(int Id);



    }
}
