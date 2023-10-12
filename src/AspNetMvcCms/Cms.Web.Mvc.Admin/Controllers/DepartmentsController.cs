using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
	public class DepartmentsController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiDepartment = "https://localhost:7188/api/Departments";

		public DepartmentsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ActionResult> GetDepartments()
		{
			var model = await _httpClient.GetFromJsonAsync<List<DepartmentEntity>>(_apiDepartment);
			return View(model);
		}
        [HttpGet]
        public IActionResult AddBlogs()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddDepartments(DepartmentViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }


            var blogEntity = new DepartmentEntity
            {

                Name = dto.Name,
                Description = dto.Description,
              

            };
            var response = await _httpClient.PostAsJsonAsync(_apiDepartment, blogEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla kaydedildi.";
            }

            return View(dto);

        }
        [HttpGet]
        public async Task<ActionResult> UpdateDepartments(int id)
        {
            // İlgili blogun bilgilerini almak için id kullanın
            var blog = await _httpClient.GetFromJsonAsync<DepartmentEntity>($"{_apiDepartment}/{id}");
            if (blog == null)
            {
                return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Blog bilgilerini bir DTO'ya aktarabilirsiniz
            var departmenDto = new DepartmentViewModel
            {
                Id = id,
                Name = blog.Name,
                Description = blog.Description,
                
            };

            return View(departmenDto);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateDepartments(int id, BlogViewModel dto)
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
                BlogCategoryId = dto.BlogCategoryId
            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiDepartment}/{id}", blogEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
            }

            return View(dto);
        }



    }
}

