using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Patient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDComment = "https://localhost:7188/api/DoctorComment";
        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DoctorCommentEntity>>(_apiDComment);

            return View(model);
        }

    }
}