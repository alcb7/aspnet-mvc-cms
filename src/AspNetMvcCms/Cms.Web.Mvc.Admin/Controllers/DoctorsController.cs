using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDoctor = "https://localhost:7188/api/Doctors";
      
        public DoctorsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> GetDoctors()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiDoctor);

            return View(model);
        }

       
    }
}
