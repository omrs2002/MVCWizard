using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWizard.Data.Enums;
using MVCWizard.Web.Application.Services;
using MVCWizard.Web.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MVCWizard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;


        public HomeController(
            IEmployeeService employeeService,
            ILogger<HomeController> logger
            )
        {
            _employeeService = employeeService; 
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> Step()
        {
            ViewBag.Employees =await _employeeService.GetAllEmployees();
            IList<object> gender_list = new List<object>()
            {new  { ID="1",Name="Male"}, new { ID = "2", Name = "Female" } };
            //var gender_list =  new SelectList(Enum.GetValues(typeof(Gender)));
            ViewBag.GenderList = new SelectList(gender_list,"ID","Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public IActionResult Create([Bind("DateOfBirth", "Dept", "FullName", "Bio", "Salary", "Gender", "DateOfStart")] EmployeeDto emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}