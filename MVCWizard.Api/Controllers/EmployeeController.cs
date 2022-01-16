using Microsoft.AspNetCore.Mvc;
using MVCWizard.Api.Application.Contracts;
using MVCWizard.Data.Models;


namespace MVCWizard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeRepository _dbcontext;
        public EmployeeController(IEmployeeRepository dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {

            return await _dbcontext.GetAllEmployeesAsync();

         
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee?>> Get(int id)
        {
            return await _dbcontext.GetEmployeeByIDAsync(id);
        

    }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Employee emp)
        {
            return await _dbcontext.CreateAsync(emp);
            
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] Employee emp)
        {
            if (emp != null)
            {
               await _dbcontext.UpdateAsync(emp);
                return true;
            }
            return false;

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _dbcontext.DeleteAsync(id);
        }
    }
}
