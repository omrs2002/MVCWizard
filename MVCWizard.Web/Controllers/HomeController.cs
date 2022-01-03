using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWizard.Data.Enums;
using MVCWizard.Web.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MVCWizard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;


        public HomeController(
            HttpClient httpClient,

            ILogger<HomeController> logger
            )
        {
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.BaseAddress = new Uri("https://localhost:7094/");
        }

        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> Step()
        {

            var response = _httpClient.GetAsync("api/Employee").Result;

            string responseString = await response.Content.ReadAsStringAsync();
            if (response != null)
            {
                if (responseString != null && !string.IsNullOrEmpty(responseString))
                {
                    List<EmployeeDto> AllEmps
                        = JsonSerializer
                        .Deserialize<List<EmployeeDto>>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            IList<object> gender_list = new List<object>()
            {new  { ID="1",Name="Male"}, new { ID = "2", Name = "Female" } };

            //var gender_list =  new SelectList(Enum.GetValues(typeof(Gender)));
            ViewBag.GenderList = new SelectList(gender_list);

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