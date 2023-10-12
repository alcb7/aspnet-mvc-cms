using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HttpClient _httpClient;


        private readonly string _apiAppointment = "https://localhost:7188/api/Appointment";
        public AppointmentsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> GetAppointments()
        {
            var model = await _httpClient.GetFromJsonAsync<List<AppointmentEntity>>(_apiAppointment);

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteAppointments(int id)
        {
            // İlgili departmanın bilgilerini almak için id kullanın
            var department = await _httpClient.GetFromJsonAsync<AppointmentEntity>($"{_apiAppointment}/{id}");
            if (department == null)
            {
                return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Silme işlemi için HTTP DELETE isteği gönderin
            var response = await _httpClient.DeleteAsync($"{_apiAppointment}/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla silindi.";
                return RedirectToAction("GetAppointments"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
            }
            else
            {
                ViewBag.Message = "Departman silinemedi.";
                return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
            }
        }
    }
}
