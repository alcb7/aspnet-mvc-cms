using Cms.Data.Models.Entities;

using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class BlogsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBlog = "https://localhost:7188/api/Blogs";
        private readonly string _apibCategories = "https://localhost:7188/api/BlogCategories";

        public BlogsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> GetBlogs()
        {
            var model = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);
            var model1 = await _httpClient.GetFromJsonAsync<List<BlogCategoryEntity>>(_apibCategories);
            var viewModel = new BlogModel
            {
                blogs = model,
                blogcategories = model1,
                
               
            };


            return View(viewModel);

           
        }

        [HttpGet]
        public async Task<ActionResult> AddBlogs()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<BlogCategoryEntity>>(_apibCategories);
            var categoryList = new SelectList(categories, "Id", "Title"); // Kategori verilerini SelectListItem koleksiyonuna dönüştürün
            ViewBag.CategoryList = categoryList; // ViewData veya ViewBag kullanarak seçenekleri görünüme aktarın
 
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
                CategoryId = dto.BlogCategoryId

            };
            var response = await _httpClient.PostAsJsonAsync(_apiBlog, blogEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla kaydedildi.";
                return RedirectToAction("GetBlogs");

            }

            return View(dto);

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
                BlogCategoryId = blog.CategoryId
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
                CategoryId = dto.BlogCategoryId
            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiBlog}/{id}", blogEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
                return RedirectToAction("GetBlogs");

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
                ViewBag.SuccessMessage = "Departman Başarıyla silindi.";
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