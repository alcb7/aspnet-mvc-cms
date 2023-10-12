using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

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

        [HttpGet]
        public IActionResult AddDoctors()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddDoctors(DoctorViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }


            var doctorEntity = new DoctorEntity
            {

                Name = dto.Name,
                Surname = dto.Surname,
                CategoryId = dto.CategoryId

            };
            var response = await _httpClient.PostAsJsonAsync(_apiDoctor, doctorEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Doktor Başarıyla kaydedildi.";
            }

            return View(dto);

        }

        [HttpGet]
        public async Task<ActionResult> UpdateDoctors(int id)
        {
            // İlgili blogun bilgilerini almak için id kullanın
            var doctor = await _httpClient.GetFromJsonAsync<DoctorEntity>($"{_apiDoctor}/{id}");
            if (doctor == null)
            {
                return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Blog bilgilerini bir DTO'ya aktarabilirsiniz
            var doctorDto = new DoctorViewModel
            {
                Id = id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                CategoryId = doctor.CategoryId
            };

            return View(doctorDto);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateDoctors(int id, DoctorViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var doctorEntity = new DoctorEntity
            {
                Id = id,
                Name = dto.Name,
                Surname = dto.Surname,
                CategoryId = dto.CategoryId
            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiDoctor}/{id}", doctorEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
            }

            return View(dto);
        }

    }
}
