using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Doctor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Doctor.Controllers
{
	public class PatientsController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiPatient = "https://localhost:7188/api/Patients";

		public PatientsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<ActionResult> GetPatients()
		{
			var model = await _httpClient.GetFromJsonAsync<List<PatientEntity>>(_apiPatient);

			return View(model);
		}
		[HttpGet]
		public async Task<ActionResult> UpdatePatients(int id)
		{
			// İlgili blogun bilgilerini almak için id kullanın
			var blog = await _httpClient.GetFromJsonAsync<PatientEntity>($"{_apiPatient}/{id}");
			if (blog == null)
			{
				return NotFound(); // Blog bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
			}

			// Blog bilgilerini bir DTO'ya aktarabilirsiniz
			var patientDto = new PatientViewModel
			{
				Id = id,
				Name = blog.Name,
				Surname = blog.Surname,
				Email = blog.Email,

			};

			return View(patientDto);
		}

		[HttpPost]
		public async Task<ActionResult> UpdatePatients(int id, PatientViewModel dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}
			var patientEntity = new PatientEntity
			{
				Id = id,
				Name = dto.Name,
				Surname = dto.Surname,
				Email = dto.Email,

			};


			// Güncelleme işlemi için HTTP PUT veya PATCH isteği gönderin
			var response = await _httpClient.PutAsJsonAsync($"{_apiPatient}/{id}", patientEntity);

			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Blog Başarıyla güncellendi.";
			}

			return View(dto);
		}
		[HttpPost]
		public async Task<ActionResult> DeletePatients(int id)
		{
			// İlgili departmanın bilgilerini almak için id kullanın
			var department = await _httpClient.GetFromJsonAsync<PatientEntity>($"{_apiPatient}/{id}");
			if (department == null)
			{
				return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
			}

			// Silme işlemi için HTTP DELETE isteği gönderin
			var response = await _httpClient.DeleteAsync($"{_apiPatient}/{id}");

			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Departman Başarıyla silindi.";
				return RedirectToAction("GetPatients"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
			}
			else
			{
				ViewBag.Message = "Departman silinemedi.";
			// Silme başarısızsa geri dönün veya başka bir işlem yapın.
			}
            return RedirectToAction("GetPatients");
        }


	}
}
