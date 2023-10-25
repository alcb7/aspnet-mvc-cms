using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Cms.Web.Mvc.Patient.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDoctorCategory = "https://localhost:7188/api/DoctorCategory";

        private readonly string _apiDoctor = "https://localhost:7188/api/Doctors";

        private readonly string _apiAppointment = "https://localhost:7188/api/Appointment";
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
        [HttpPost]
        public async Task<ActionResult> Index(AppointmentEntity entity)
        {
            //var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            var AppointmentEntity = new AppointmentEntity
            {

                DoctorCategoryId = entity.DoctorCategoryId,
                DoctorId = entity.DoctorId,
                DateTime = entity.DateTime

            };
            var response = await _httpClient.PostAsJsonAsync(_apiAppointment, AppointmentEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Doktor Başarıyla kaydedildi.";
            }

            return View(entity);
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

//[HttpGet]
//public IActionResult AddDoctors()
//{
//    return View();
//}
//[HttpPost]
//public async Task<ActionResult> AddDoctors(DoctorViewModel dto)
//{
//    if (!ModelState.IsValid)
//    {
//        return View(dto);
//    }


//    var doctorEntity = new DoctorEntity
//    {

//        Name = dto.Name,
//        Surname = dto.Surname,
//        CategoryId = dto.CategoryId

//    };
//    var response = await _httpClient.PostAsJsonAsync(_apiDoctor, doctorEntity);
//    if (response.IsSuccessStatusCode)
//    {
//        ViewBag.Message = "Doktor Başarıyla kaydedildi.";
//    }

//    return View(dto);

//}
