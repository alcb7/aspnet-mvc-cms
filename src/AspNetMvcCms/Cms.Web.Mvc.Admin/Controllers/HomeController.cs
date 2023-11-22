using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiAdmin = "https://api.canbulanhospital.com/api/Admins/";

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));
            if (userId == null || userId == 0)
            {
                string otherMvcProjectUrl = "https://admin.canbulanhospital.com/login";
                return Redirect(otherMvcProjectUrl);
            }
            // Doktorun randevularını API'den çekmek için gerekli isteği yapın.
            var response = await _httpClient.GetAsync($"{_apiAdmin}{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var doctorAppointments = await response.Content.ReadFromJsonAsync<AdminEntity>();

            // ViewBag veya ViewData ile kullanıcı kimliğini görünüme aktarabilirsiniz.
            //ViewBag.UserId = userId;

            return View(doctorAppointments);
        }

    }
}