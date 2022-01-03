using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWizard.Web.Models;
using System.Diagnostics;

namespace MVCWizard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(
            ILogger<HomeController> logger
            )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Step()
        {
            IList<object> gender_list =new List<object>() 
            {new  { ID="1",Name="Male"}, new { ID = "2", Name = "Female" } };

             ViewBag.GenderList = new SelectList(gender_list, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public IActionResult Create([Bind("DateOfBirth", "Dept", "FullName", "Bio", "Salary", "Gender", "DateOfStart")]EmployeeDto emp)
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