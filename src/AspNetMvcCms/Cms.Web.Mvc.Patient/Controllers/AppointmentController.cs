using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly HttpClient _httpClient;


        private readonly string _apiDcategories = "https://localhost:7188/api/DoctorCategories/";
        public AppointmentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DoctorCategoryEntity>>(_apiDcategories);

            return View(model);
        }
    }
}
