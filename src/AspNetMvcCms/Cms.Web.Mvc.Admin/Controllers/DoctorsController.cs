using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Numerics;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDoctor = "https://localhost:7188/api/Doctors";
        private readonly string _apiCategories = "https://localhost:7188/api/DoctorCategory";
        private readonly string _yourFileStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", "files");


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
        public async Task<ActionResult> AddDoctors()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<DoctorCategoryEntity>>(_apiCategories); // Kategori verilerini alın
            var categoryList = new SelectList(categories, "Id", "Name"); // Kategori verilerini SelectListItem koleksiyonuna dönüştürün
            ViewBag.CategoryList = categoryList; // ViewData veya ViewBag kullanarak seçenekleri görünüme aktarın

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddDoctors(DoctorViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
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
                ResimDosyaAdi = await UploadPhoto(dto.ResimDosyaAdi),
                Cat = GetCatValue(dto.CategoryId)
            };

            var response = await _httpClient.PostAsJsonAsync(_apiDoctor, doctorEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Doktor başarıyla eklendi.";
                return RedirectToAction("GetDoctors");
            }

            return View(dto);
        }
        private string GetCatValue(int categoryId)
        {
            switch (categoryId)
            {
                case 1:
                    return "cat1";
                case 2:
                    return "cat2";
                case 3:
                    return "cat3";
                case 4:
                    return "cat4";
                case 5:
                    return "cat5";
                case 6:
                    return "cat6";
                default:
                    return null; // veya başka bir değer döndürebilirsiniz
            }
        }

        private async Task<string> UploadPhoto(IFormFile ResimDosyaAdi)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(ResimDosyaAdi.OpenReadStream())
                {
                    Headers =
            {
                ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = ResimDosyaAdi.FileName
                }
            }
                });

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync("https://localhost:7188/api/File/upload", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var filePath = JsonConvert.DeserializeAnonymousType(result, new { filePath = "" });
                        return filePath?.filePath;
                    }
                }
            }

            return null;
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
                Password = dto.Password,

            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiDoctor}/{id}", doctorEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.SuccessMessage = "Doctor Başarıyla güncellendi.";
                return RedirectToAction("GetDoctors");
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
                ViewBag.SuccessMessage = "Departman Başarıyla silindi.";
                return RedirectToAction("GetDoctors"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
            }
            else
            {
                ViewBag.Message = "Departman silinemedi.";
                 // Silme başarısızsa geri dönün veya başka bir işlem yapın.
            }
            return RedirectToAction("GetDoctors");
        }

    }
}
