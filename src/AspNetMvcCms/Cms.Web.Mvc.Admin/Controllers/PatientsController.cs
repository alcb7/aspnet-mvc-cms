using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Cms.Web.Mvc.Admin.Controllers
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


	}
}
