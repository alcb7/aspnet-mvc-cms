
using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Web.Mvc.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiUrl = "https://localhost:7188/swagger/index.html";
        public DoctorsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiUrl);

            return View(model);
        }

        public async Task<ActionResult> Detail(int id)
        {
            // Belirli bir doktorun detaylarını getir.
            var doctor = await _httpClient.GetFromJsonAsync<DoctorEntity>($"{_apiUrl}/Doctors/{id}");

            if (doctor == null)
            {
                // Belirli bir doktor bulunamazsa hata sayfasına yönlendirme yapılabilir.
                return NotFound();
            }

            return View(doctor);
        }
    }
}
