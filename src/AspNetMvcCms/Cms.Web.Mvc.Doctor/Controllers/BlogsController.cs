using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Doctor.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Cms.Web.Mvc.Doctor.Controllers
{
	public class BlogsController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiBlog = "https://api.canbulanhospital.com/api/Blogs";

		public BlogsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ActionResult> GetBlogs()
		{
			var model = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);
			return View(model);
		}

		[HttpGet]
		public IActionResult AddBlogs()
		{
			return View();
		}
		[HttpPost]
		public async Task<ActionResult> AddBlogs(BlogViewModel dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}


			var blogEntity = new BlogEntity
			{

				Title = dto.Title,
				Description = dto.Description,
				BlogCategoryId = dto.BlogCategoryId,

                 ResimDosyaAdi = await UploadPhoto(dto.ResimDosyaAdi)
            };
			var response = await _httpClient.PostAsJsonAsync(_apiBlog, blogEntity);
			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Blog Başarıyla kaydedildi.";
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
		public async Task<ActionResult> UpdateBlogs(int id)
		{
			// İlgili blogun bilgilerini almak için id kullanın
			var blog = await _httpClient.GetFromJsonAsync<BlogEntity>($"{_apiBlog}/{id}");
			if (blog == null)
			{
				return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
			}

			// Blog bilgilerini bir DTO'ya aktarabilirsiniz
			var blogDto = new BlogViewModel
			{
				Id = id,
				Title = blog.Title,
				Description = blog.Description,
				BlogCategoryId = blog.BlogCategoryId
			};

			return View(blogDto);
		}

		[HttpPost]
		public async Task<ActionResult> UpdateBlogs(int id, BlogViewModel dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			var blogEntity = new BlogEntity
			{
				Id = id,
				Title = dto.Title,
				Description = dto.Description,
				BlogCategoryId = dto.BlogCategoryId,

                  ResimDosyaAdi = await UploadPhoto(dto.ResimDosyaAdi)
            };

			// Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
			var response = await _httpClient.PutAsJsonAsync($"{_apiBlog}/{id}", blogEntity);

			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Blog Başarıyla güncellendi.";
			}

			return View(dto);
		}
		[HttpPost]
		public async Task<ActionResult> DeleteBlogs(int id)
		{
			// İlgili departmanın bilgilerini almak için id kullanın
			var department = await _httpClient.GetFromJsonAsync<BlogEntity>($"{_apiBlog}/{id}");
			if (department == null)
			{
				return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
			}

			// Silme işlemi için HTTP DELETE isteği gönderin
			var response = await _httpClient.DeleteAsync($"{_apiBlog}/{id}");

			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Departman Başarıyla silindi.";
				return RedirectToAction("GetBlogs"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
			}
			else
			{
				ViewBag.Message = "Departman silinemedi.";
				return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
			}
		}


	}
}
