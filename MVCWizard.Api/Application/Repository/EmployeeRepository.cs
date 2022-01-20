using MVCWizard.Api.Data;
using System.Linq;
using MVCWizard.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCWizard.Api.Application.Contracts
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _employeeDB;
        public EmployeeRepository(EmployeeDBContext employeeDB)
        {
            _employeeDB = employeeDB;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeDB.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIDAsync(int Id)
        {
            return await _employeeDB.Employees.Where(emp => emp.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Employee emp)
        {

            _employeeDB.Employees.Add(emp);
            await _employeeDB.SaveChangesAsync();
            return emp.Id;
        }

        public async Task<int> UpdateAsync(Employee emp)
        {
            _employeeDB.Entry(emp).State = EntityState.Modified;
            await _employeeDB.SaveChangesAsync();
            return emp.Id;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var emp_toupdelete = await _employeeDB.Employees.Where(emp => emp.Id == emp.Id).FirstOrDefaultAsync();
            if (emp_toupdelete != null)
            {
                _employeeDB.Employees.Remove(emp_toupdelete);
                await _employeeDB.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
