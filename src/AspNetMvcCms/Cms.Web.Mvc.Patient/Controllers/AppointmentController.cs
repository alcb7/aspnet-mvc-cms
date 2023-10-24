using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDoctorCategory = "https://localhost:7188/api/DoctorCategory";

        private readonly string _apiDoctor = "https://localhost:7188/api/Doctors";
        public AppointmentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
    

            var model = await _httpClient.GetFromJsonAsync<List<DoctorCategoryEntity>>(_apiDoctorCategory);

            ViewBag.DepartmentId = new SelectList(model, "Id", "Name");
            return View();
        }
     
  
        public async Task<JsonResult> LoadDoctor(int categoryId)
        {
            List<DoctorEntity>? doctorlist = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiDoctor);

            List<DoctorEntity>? newDoctors = doctorlist?
                .Where(d => d.CategoryId == categoryId)
                .ToList();

            return Json(new SelectList(newDoctors, "Id" ,"Name"));
        }
       
    }

}
