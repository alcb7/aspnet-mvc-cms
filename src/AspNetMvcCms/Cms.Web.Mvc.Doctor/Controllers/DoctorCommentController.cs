using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Doctor.Controllers
{
    public class DoctorCommentController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDComment = "https://localhost:7188/api/DoctorComment";

        public DoctorCommentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> GetDoctorComments()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

            // Doktorun randevularını API'den çekmek için gerekli isteği yapın.
            var response = await _httpClient.GetAsync($"{_apiDComment}/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var doctor = await response.Content.ReadFromJsonAsync<DoctorCommentEntity>();

            // ViewBag veya ViewData ile kullanıcı kimliğini görünüme aktarabilirsiniz.
            //ViewBag.UserId = userId;

            return View(doctor);
        }
    }
}
