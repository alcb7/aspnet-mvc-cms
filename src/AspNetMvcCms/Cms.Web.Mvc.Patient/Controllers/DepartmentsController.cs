using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDepartment = "https://localhost:7188/api/Departments";
        public DepartmentsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DepartmentEntity>>(_apiDepartment);

            return View(model);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
