using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
	public class PanelController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiDoctor = "https://localhost:7188/api/Doctors";
		private readonly string _apiPatient = "https://localhost:7188/api/Patients";
        private readonly string _apiBlog = "https://localhost:7188/api/Blogs";
        public PanelController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<ActionResult> Doctors()
		{
			var model = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiDoctor);

			return View(model);
		}

		public async Task<ActionResult> Patients()
		{
			var model = await _httpClient.GetFromJsonAsync<List<PatientEntity>>(_apiPatient);

			return View(model);
		}
        public async Task<ActionResult> Blogs()
        {
            var model = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);

            return View(model);
        }
    }
}
