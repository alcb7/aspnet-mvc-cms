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
                CategoryId = dto.CategoryId,
                Phone = dto.Phone,
                Address = dto.Address,
                Cv = dto.Cv,
                Email = dto.Email,
                Password = dto.Password,

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
                CategoryId = doctor.CategoryId,
                Phone = doctor.Phone,
                Address = doctor.Address,
                Cv = doctor.Cv,
                Email = doctor.Email,
                Password = doctor.Password,
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
                CategoryId = dto.CategoryId,
                Phone = dto.Phone,
                Address = dto.Address,
                Cv = dto.Cv,
                Email = dto.Email,
                Password= dto.Password,

            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiDoctor}/{id}", doctorEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
            }

            return View(dto);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteDoctors(int id)
        {
            
            // İlgili departmanın bilgilerini almak için id kullanın
            var doctor = await _httpClient.GetFromJsonAsync<DoctorEntity>($"{_apiDoctor}/{id}");
            if (doctor == null)
            {
                return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Silme işlemi için HTTP DELETE isteği gönderin
            var response = await _httpClient.DeleteAsync($"{_apiDoctor}/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla silindi.";
                return RedirectToAction("GetDoctors"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
            }
            else
            {
                ViewBag.Message = "Departman silinemedi.";
                return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
            }
        }

    }
}
