using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
	public class NavbarController : Controller
	{
		private readonly HttpClient _httpClient;

		private readonly string _apiNavbar = "http://api.canbulanhospital.com/api/Navbar";
		public NavbarController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<ActionResult> Index()
		{
			var model = await _httpClient.GetFromJsonAsync<List<NavbarEntity>>(_apiNavbar);

			return View(model);
		}
	}
}
