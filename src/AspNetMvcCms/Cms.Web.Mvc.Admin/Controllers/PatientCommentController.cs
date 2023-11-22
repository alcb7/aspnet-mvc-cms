using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class PatientCommentController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiPComment = "https://api.canbulanhospital.com/api/PatientComment";

        public PatientCommentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult> GetPatientComment()
        {
            var model = await _httpClient.GetFromJsonAsync<List<PatientCommentEntity>>(_apiPComment);

            return View(model);
        }
      
        [HttpPost]
        public async Task<ActionResult> DeletePComment(int id)
        {
            // İlgili departmanın bilgilerini almak için id kullanın
            var department = await _httpClient.GetFromJsonAsync<PatientCommentEntity>($"{_apiPComment}/{id}");
            if (department == null)
            {
                return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Silme işlemi için HTTP DELETE isteği gönderin
            var response = await _httpClient.DeleteAsync($"{_apiPComment}/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla silindi.";
                return RedirectToAction(nameof(GetPatientComment)); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
            }
            else
            {
                ViewBag.Message = "Departman silinemedi.";
                return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
            }
        }





    }
}

