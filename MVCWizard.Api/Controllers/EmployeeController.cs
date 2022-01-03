using Microsoft.AspNetCore.Mvc;
using MVCWizard.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCWizard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {

            return new List<Employee>() { new Employee{ Id=1, FullName= "Omar" } };
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return new Employee { Id = 1, FullName = "Omar" };
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Employee emp)
        {
            return emp.Id;

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Employee emp)
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
