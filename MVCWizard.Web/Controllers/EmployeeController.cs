using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWizard.Web.Application;
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
            //return View(Employee);
            return PartialView(Employee);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> Edit([Bind("Id","DateOfBirth", "Dept", "FullName", "Bio", "Salary", "Gender", "DateOfStart")] EmployeeDto emp)
        {
            if (!ModelState.IsValid)
            {
                string errors = "";
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Concat("," + error.ErrorMessage);  
                    }
                }
                
                //return Ok(errors);
                return PartialView(Constants.PartialNames.EmployeeEdit,emp);
            }

            var Employee = await _employeeService.UpdateAsync(emp);
            //return RedirectToAction("Index");
            return PartialView(Constants.PartialNames.EmployeeDetails, emp);
        }



        // GET: EmployeeController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int emp_id)
        {
            var Employee = await _employeeService.GetEmployeeByIDAsync(emp_id);
            return PartialView(Constants.PartialNames.EmployeeDelete, Employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(int emp_id)
        {
                var result = await _employeeService.DeleteAsync(emp_id);
                return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsPartialViewAsync()
        {
            var Employees = await _employeeService.GetAllEmployeesAsync();
            return PartialView(Constants.PartialNames.EmployeeList, Employees);

        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetailsAsync(int emp_id)
        {
            var Employee = await _employeeService.GetEmployeeByIDAsync(emp_id);
            return PartialView(Constants.PartialNames.EmployeeDetails, Employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeEditAsync(int emp_id)
        {
            var Employee = await _employeeService.GetEmployeeByIDAsync(emp_id);
            return PartialView(Constants.PartialNames.EmployeeEdit, Employee);

        }

    }
}
