using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Doctor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using System.Security.Claims;

namespace Cms.Web.Mvc.Doctor.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDoctor = "https://localhost:7188/api/Doctors";

        public DoctorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> GetDoctor()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

            // Doktorun randevularını API'den çekmek için gerekli isteği yapın.
            var response = await _httpClient.GetAsync($"{_apiDoctor}/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var doctor = await response.Content.ReadFromJsonAsync<DoctorEntity>();

            // ViewBag veya ViewData ile kullanıcı kimliğini görünüme aktarabilirsiniz.
            //ViewBag.UserId = userId;

            return View(doctor);
        }

        
        [HttpGet]
        public async Task<ActionResult> UpdateDoctor()
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));
            // İlgili blogun bilgilerini almak için id kullanın
            var doctor = await _httpClient.GetFromJsonAsync<DoctorEntity>($"{_apiDoctor}/{id}");
            if (doctor == null)
            {
                return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Blog bilgilerini bir DTO'ya aktarabilirsiniz
            var doctorvm= new DoctorUpdateViewModel
            {
                Id = id,
                CategoryId=doctor.CategoryId,
                Name= doctor.Name,
                Surname = doctor.Surname,
                Address = doctor.Address,
                Cv = doctor.Cv,
                Phone = doctor.Phone,
                Email = doctor.Email,
                
            };

            return View(doctorvm);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateDoctor( DoctorUpdateViewModel doctorvm)
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));


            if (!ModelState.IsValid)
            {
                return View(doctorvm);
            }

            var doctorEntity = new DoctorEntity
            {

                Id = id,
                CategoryId = doctorvm.CategoryId,
                Name = doctorvm.Name,
                Surname = doctorvm.Surname,
                Address = doctorvm.Address,
                Cv = doctorvm.Cv,
                Phone = doctorvm.Phone,
                Email = doctorvm.Email,
            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiDoctor}/{id}", doctorEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
            }

            return View(doctorvm);
        }
        


    }


}