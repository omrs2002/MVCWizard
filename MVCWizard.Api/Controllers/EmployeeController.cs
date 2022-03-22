using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MVCWizard.Api.Application.Contracts;
using MVCWizard.Data.Models;
using System.Text;
using System.Text.Json;

namespace MVCWizard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeRepository _dbcontext;
        readonly IDistributedCache _distributedCache;

        public EmployeeController(
            IEmployeeRepository dbcontext,
            IDistributedCache distributedCache
            )
        {
            _dbcontext = dbcontext;
            _distributedCache = distributedCache;
        }

        [HttpGet("Get")]
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
        [HttpPost("Post")]
        public async Task<ActionResult<int>> Post([FromBody] Employee emp)
        {
            return await _dbcontext.CreateAsync(emp);

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("Put")]
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

        [HttpGet("GetDateFromRedis")]
        public async Task<string> GetDate()
        {
            var cacheKey = "datenow";
            string serializeddatenow;
            DateTime datenow;

            var redis_datenow= await _distributedCache.GetAsync(cacheKey);
            if (redis_datenow != null)
            {
                serializeddatenow = Encoding.UTF8.GetString(redis_datenow);
                datenow = JsonSerializer.Deserialize<DateTime>(serializeddatenow);
            }
            else
            {
                datenow = DateTime.Now;
                serializeddatenow = JsonSerializer.Serialize(datenow);
                redis_datenow = Encoding.UTF8.GetBytes(serializeddatenow);
                
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));

                await _distributedCache.SetAsync(cacheKey, redis_datenow, options);
            }
            return datenow.ToString("dd-MM-yyyy HH:mm:ss");
        }




    }
}
