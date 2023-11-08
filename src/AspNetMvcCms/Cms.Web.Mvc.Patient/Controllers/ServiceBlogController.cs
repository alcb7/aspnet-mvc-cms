using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class ServiceBlogController : Controller
    {
        private readonly HttpClient _httpClient;


        private readonly string _apiSBlogs = "https://localhost:7188/api/ServiceBlog/";



        public ServiceBlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> GetServiceBlogs()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ServiceBlogEntity>>(_apiSBlogs);







            return View(model);

        }
		public async Task<ActionResult> Detail(int id)
		{
			// Belirli bir doktorun detaylarını getir.
			ServiceBlogEntity? doctor = await _httpClient.GetFromJsonAsync<ServiceBlogEntity>(_apiSBlogs + id);

			if (doctor == null)
			{
				// Belirli bir doktor bulunamazsa hata sayfasına yönlendirme yapılabilir.
				return NotFound();
			}

			return View(doctor);
		}
	}
}
