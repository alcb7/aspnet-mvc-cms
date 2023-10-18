using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HttpClient _httpClient;


        private readonly string _apiDepartment = "https://localhost:7188/api/Departments/";
        public AppointmentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
