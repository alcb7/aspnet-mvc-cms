using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDoctor = "https://localhost:7188/api/Doctors/";
        public AppointmentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public async Task<JsonResult> LoadDoctor(int categoryId)
        //{
        //    var doctorlist = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiDoctor);

        //    var newDoctors = doctorlist?.Where(d => d.CategoryId == categoryId).ToList();


        //    return Json(new SelectList(newDoctors, "Id", "Name"));
        //}
        [HttpGet]
        public async Task<JsonResult> LoadDoctor(int categoryId)
        {
            var doctorlist = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiDoctor);

            var newDoctors = doctorlist?
                .Where(d => d.CategoryId == categoryId)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name // veya d.FullName veya başka bir özellik
                })
                .ToList();

            return Json(newDoctors);
        }

    }

}
