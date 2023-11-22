using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Security.Claims;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class SettingsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiAdmin = "https://api.canbulanhospital.com/api/Admins";

        public SettingsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> GetAdmin()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

            // Doktorun randevularını API'den çekmek için gerekli isteği yapın.
            var response = await _httpClient.GetAsync($"{_apiAdmin}/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var doctor = await response.Content.ReadFromJsonAsync<AdminEntity>();

            // ViewBag veya ViewData ile kullanıcı kimliğini görünüme aktarabilirsiniz.
            //ViewBag.UserId = userId;

            return View(doctor);
        }

        [HttpGet]
        public async Task<ActionResult> UpdateAdmin()
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));
            // İlgili blogun bilgilerini almak için id kullanın
            var doctor = await _httpClient.GetFromJsonAsync<AdminEntity>($"{_apiAdmin}/{id}");
            if (doctor == null)
            {
                return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Blog bilgilerini bir DTO'ya aktarabilirsiniz
            var doctorvm = new AdminUpdateViewModel
            {
                Id = id,
                Password = doctor.Password,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Address = doctor.Address,
                Cv = doctor.Cv,
                Phone = doctor.Phone,
                Email = doctor.Email,

            };

            return View(doctorvm);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAdmin(AdminUpdateViewModel doctorvm)
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));


            if (!ModelState.IsValid)
            {
                return View(doctorvm);
            }

            var doctorEntity = new DoctorEntity
            {

                Id = id,
                Password = doctorvm.Password,
                Name = doctorvm.Name,
                Surname = doctorvm.Surname,
                Address = doctorvm.Address,
                Cv = doctorvm.Cv,
                Phone = doctorvm.Phone,
                Email = doctorvm.Email,
            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiAdmin}/{id}", doctorEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
                return RedirectToAction("GetAdmin");
            }

            return View(doctorvm);
        }




    }
}

