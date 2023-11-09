using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBlog = "https://localhost:7188/api/Blogs/";
        public BlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);

            return View(model);
        }

        public async Task<ActionResult> Detail(int id)
        {
            // Belirli bir doktorun detaylarını getir.
            BlogEntity? doctor = await _httpClient.GetFromJsonAsync<BlogEntity>(_apiBlog + id);

            if (doctor == null)
            {
                // Belirli bir doktor bulunamazsa hata sayfasına yönlendirme yapılabilir.
                return NotFound();
            }

            return View(doctor);
        }
    }
}
