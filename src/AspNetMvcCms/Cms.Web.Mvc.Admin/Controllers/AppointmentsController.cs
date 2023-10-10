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
    }
}
