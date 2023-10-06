using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cms.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiNavbar = "https://localhost:7188/api/Navbar";
        public HomeController(HttpClient httpClient)
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