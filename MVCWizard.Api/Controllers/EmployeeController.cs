using Microsoft.AspNetCore.Mvc;
using MVCWizard.Data.Models;

namespace MVCWizard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {

            return new List<Employee>() 
            { 
                new Employee
                { 
                    Id=1, FullName= "Omar", Bio  ="My CV", CompletionStatus=1, 
                    DateOfBirth = DateTime.Now.AddYears(-38), DateOfStart=DateTime.Now,
                    Dept="Account", Gender=1, Salary=4000
                },
                 new Employee
                {
                    Id=2, FullName= "Noor", Bio  ="My CV", CompletionStatus=1,
                    DateOfBirth = DateTime.Now.AddYears(-32), DateOfStart=DateTime.Now,
                    Dept="Account", Gender=2, Salary=9000
                }

            };
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            return new Employee
            {
                Id = 1,
                FullName = "Omar",
                Bio = "My CV",
                CompletionStatus = 1,
                DateOfBirth = DateTime.Now.AddYears(-38),
                DateOfStart = DateTime.Now,
                Dept = "Account",
                Gender = 1,
                Salary = 4000
            };
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Employee emp)
        {
            return 55;

        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] Employee emp)
        {
            if (emp != null)
            {
                return true;
            }
            return false;

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
