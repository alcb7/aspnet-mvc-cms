using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

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
        public IActionResult AddDepartments()
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
                ResimDosyaAdi = await UploadPhoto(dto.ResimDosyaAdi)


            };
            var response = await _httpClient.PostAsJsonAsync(_apiDepartment, blogEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.SuccessMessage = "Departman Başarıyla kaydedildi.";
                
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
        public async Task<ActionResult> UpdateDepartments(int id, DepartmentViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var departmentEntity = new DepartmentEntity
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description,
				ResimDosyaAdi = await UploadPhoto(dto.ResimDosyaAdi),

			};

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiDepartment}/{id}", departmentEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
                return RedirectToAction("GetDepartments");
            }

            return View(dto);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteDepartments(int id)
        {
            // İlgili departmanın bilgilerini almak için id kullanın
            var department = await _httpClient.GetFromJsonAsync<DepartmentEntity>($"{_apiDepartment}/{id}");
            if (department == null)
            {
                return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Silme işlemi için HTTP DELETE isteği gönderin
            var response = await _httpClient.DeleteAsync($"{_apiDepartment}/{id}");

            if (response.IsSuccessStatusCode)
            {
				ViewBag.SuccessMessage = "Departman Başarıyla silindi.";
				return RedirectToAction("GetDepartments"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
			}
            else
            {
                ViewBag.Error = "Departman silinemedi.";
             
            }
			return RedirectToAction("GetDepartments");
		}




    }
}

