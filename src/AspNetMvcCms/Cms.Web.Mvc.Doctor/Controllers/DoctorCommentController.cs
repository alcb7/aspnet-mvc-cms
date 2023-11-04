using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Doctor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Doctor.Controllers
{
	[Authorize]

	public class DoctorCommentController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiDComment = "https://localhost:7188/api/DoctorComment";

		public DoctorCommentController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		[HttpGet]
		public async Task<ActionResult> GetDoctorComment()
		{
			var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

			var response = await _httpClient.GetAsync($"{_apiDComment}/{userId}");
			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode);
			}
			var model = await response.Content.ReadFromJsonAsync<List<DoctorCommentEntity>>();
			return View(model);
		}

		[HttpGet]
		public IActionResult AddDoctorComment()
		{
			return View();
		}
		[HttpPost]
		public async Task<ActionResult> AddDoctorComment(DoctorCommentViewModel dto)
		{

			if (!ModelState.IsValid)
			{
				return View(dto);
			}
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

            // Kullanıcının kimliğini DoctorId'ye eşleme
            dto.DoctorId = userId;

            var dcommentEntity = new DoctorCommentEntity
			{

				Title = dto.Title,
				Description = dto.Description,
                DoctorId = dto.DoctorId

            };
			var response = await _httpClient.PostAsJsonAsync(_apiDComment, dcommentEntity);
			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Departman Başarıyla kaydedildi.";
			}

			return View(dto);
		}

        [HttpGet]
        public async Task<ActionResult> UpdateDoctorComment(int id)
        {
            // İlgili blogun bilgilerini almak için id kullanın
            var blog = await _httpClient.GetFromJsonAsync<DoctorCommentEntity>($"{_apiDComment}/{id}");
            if (blog == null)
            {
                return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Blog bilgilerini bir DTO'ya aktarabilirsiniz
            var blogDto = new DoctorCommentEntity
            {
                Id = id,
                Title = blog.Title,
                Description = blog.Description,
                DoctorId = blog.DoctorId
            };

            return View(blogDto);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateDoctorComment(int id, DoctorCommentViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

            // Kullanıcının kimliğini DoctorId'ye eşleme
            dto.DoctorId = userId;
            var blogEntity = new DoctorCommentEntity
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,
                DoctorId = dto.DoctorId
            };

            // Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
            var response = await _httpClient.PutAsJsonAsync($"{_apiDComment}/{id}", blogEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla güncellendi.";
            }

            return View(dto);
        }

        [HttpPost]
		public async Task<ActionResult> DeleteDComment(int id)
		{
			// İlgili departmanın bilgilerini almak için id kullanın
			var department = await _httpClient.GetFromJsonAsync<DoctorCommentEntity>($"{_apiDComment}/{id}");
			if (department == null)
			{
				return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
			}

			// Silme işlemi için HTTP DELETE isteği gönderin
			var response = await _httpClient.DeleteAsync($"{_apiDComment}/{id}");

			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Departman Başarıyla silindi.";
				return RedirectToAction("GetDepartments"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
			}
			else
			{
				ViewBag.Message = "Departman silinemedi.";
				return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
			}
		}





	}

}