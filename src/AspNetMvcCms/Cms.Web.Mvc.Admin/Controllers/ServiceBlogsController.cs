using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Cms.Web.Mvc.Admin.Controllers
{
	public class ServiceBlogsController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiSblog = "https://localhost:7188/api/ServiceBlog";

		public ServiceBlogsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ActionResult> GetServiceBlogs()
		{
			var model = await _httpClient.GetFromJsonAsync<List<ServiceBlogEntity>>(_apiSblog);
			return View(model);
		}

        [HttpGet]
        public IActionResult AddServiceBlogs()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddServiceBlogs(ServiceBlogViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }


            var blogEntity = new ServiceBlogEntity
            {

                Title = dto.Title,
                Description = dto.Description,


            };
            var response = await _httpClient.PostAsJsonAsync(_apiSblog, blogEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla kaydedildi.";
            }

            return View(dto);

        }

        [HttpGet]
        public async Task<ActionResult> UpdateServiceBlogs(int id)
        {
            // İlgili blogun bilgilerini almak için id kullanın
            var blog = await _httpClient.GetFromJsonAsync<ServiceBlogEntity>($"{_apiSblog}/{id}");
            if (blog == null)
            {
                return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Blog bilgilerini bir DTO'ya aktarabilirsiniz
            var departmenDto = new ServiceBlogViewModel
            {
                Id = id,
                Title = blog.Title,
                Description = blog.Description,
               
               

            };

            return View(departmenDto);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateServiceBlogs(int id, ServiceBlogViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var departmentEntity = new ServiceBlogEntity
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,

            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiSblog}/{id}", departmentEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
            }

            return View(dto);
        }
    }
}
