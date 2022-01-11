using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWizard.Web.Application.Contracts;
using MVCWizard.Web.Models;

namespace MVCWizard.Web.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService,
            ILogger<EmployeeController> logger
            )
        {
            _employeeService = employeeService;
            _logger = logger;
        }


        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var Employees = await _employeeService.GetAllEmployeesAsync();
            return View(Employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Create([Bind("DateOfBirth", "Dept", "FullName", "Bio", "Salary", "Gender", "DateOfStart")] EmployeeDto emp)
        {
            if (!ModelState.IsValid)
            {
                return  BadRequest();
            }
            int empid = await _employeeService.CreateAsync(emp);
            return RedirectToAction("Index");
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            
            var Employee = await _employeeService.GetEmployeeByIDAsync(id);
            return View(Employee);
        }

        
        public async Task<ActionResult> Edit(int id)
        {
            IList<object> gender_list = new List<object>()
            {new  { ID="1",Name="Male"}, new { ID = "2", Name = "Female" } };
            ViewBag.GenderList = new SelectList(gender_list, "ID", "Name");

            var Employee = await _employeeService.GetEmployeeByIDAsync(id);
            return View(Employee);
        }


        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            IList<object> gender_list = new List<object>()
            {new  { ID="1",Name="Male"}, new { ID = "2", Name = "Female" } };
            ViewBag.GenderList = new SelectList(gender_list, "ID", "Name");

            var Employee = new EmployeeDto();
            return View(Employee);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id","DateOfBirth", "Dept", "FullName", "Bio", "Salary", "Gender", "DateOfStart")] EmployeeDto emp)
        {
            IList<object> gender_list = new List<object>()
            {new  { ID="1",Name="Male"}, new { ID = "2", Name = "Female" } };
            ViewBag.GenderList = new SelectList(gender_list, "ID", "Name");

            var Employee = await _employeeService.UpdateAsync(emp);

            return View(Employee);
            
        }

       

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
