using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
	public class DepartmentsController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiContact = "https://localhost:7188/api/Departments";

		public DepartmentsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ActionResult> GetDepartments()
		{
			var model = await _httpClient.GetFromJsonAsync<List<DepartmentEntity>>(_apiContact);
			return View(model);
		}
	}
}
