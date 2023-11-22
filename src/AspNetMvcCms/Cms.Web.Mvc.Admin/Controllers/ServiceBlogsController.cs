using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace Cms.Web.Mvc.Admin.Controllers
{
	public class ServiceBlogsController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiSblog = "https://api.canbulanhospital.com/api/ServiceBlog";
        private readonly string _yourFileStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", "files");
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
                ResimDosyaAdi = await UploadPhoto(dto.ResimDosyaAdi)

            };
            var response = await _httpClient.PostAsJsonAsync(_apiSblog, blogEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla kaydedildi.";
                return RedirectToAction("GetServiceBlogs");

            }

            return View(dto);

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
                    var response = await client.PostAsync("https://api.canbulanhospital.com/api/File/upload", content);

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
                ResimDosyaAdi = await UploadPhoto(dto.ResimDosyaAdi)

            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiSblog}/{id}", departmentEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
                return RedirectToAction("GetServiceBlogs");
            }

            return View(dto);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteServiceBlogs(int id)
        {

            // İlgili departmanın bilgilerini almak için id kullanın
            var doctor = await _httpClient.GetFromJsonAsync<ServiceBlogEntity>($"{_apiSblog}/{id}");
            if (doctor == null)
            {
                return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Silme işlemi için HTTP DELETE isteği gönderin
            var response = await _httpClient.DeleteAsync($"{_apiSblog}/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla silindi.";
                return RedirectToAction("GetServiceBlogs"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
            }
            else
            {
                ViewBag.Message = "Departman silinemedi.";
                return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
            }
        }
    }
}
