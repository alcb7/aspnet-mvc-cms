using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Doctor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Cms.Web.Mvc.Doctor.Controllers
{
	public class HomeController : Controller
	{

        private readonly HttpClient _httpClient;

        private readonly string _apiDoctor = "https://api.canbulanhospital.com/api/Doctors/";

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));
            if (userId == null || userId == 0 ) 
            {
                string otherMvcProjectUrl = "https://doctor.canbulanhospital.com/login";
                return Redirect(otherMvcProjectUrl);
            }
            // Doktorun randevularını API'den çekmek için gerekli isteği yapın.
            var response = await _httpClient.GetAsync($"{_apiDoctor}{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var doctorAppointments = await response.Content.ReadFromJsonAsync<DoctorEntity>();

            // ViewBag veya ViewData ile kullanıcı kimliğini görünüme aktarabilirsiniz.
            //ViewBag.UserId = userId;

            return View(doctorAppointments);
        }

    }
}