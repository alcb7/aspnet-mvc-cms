using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class PatientsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiPatient = "https://localhost:7188/api/Patients";

        public PatientsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> GetPatients()
        {
            var model = await _httpClient.GetFromJsonAsync<List<PatientEntity>>(_apiPatient);

            return View(model);
        }


    }
}
