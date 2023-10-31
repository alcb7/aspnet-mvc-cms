using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Patient.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
	public class AboutController : Controller
	{
		private readonly HttpClient _httpClient;

		
		private readonly string _apiPComments = "https://localhost:7188/api/PatientComment";



		public AboutController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<ActionResult> Index()
		{
			var model = await _httpClient.GetFromJsonAsync<List<PatientCommentEntity>>(_apiPComments);
			



			


			return View(model);

		}

	}
}
