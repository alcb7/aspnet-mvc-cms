using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;

using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<ActionResult> GetDoctorComment()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DoctorCommentEntity>>(_apiDComment);

            return View(model);
        }
       
        [HttpPost]
        public async Task<ActionResult> DeleteDComment(int id)
        {
            // İlgili departmanın bilgilerini almak için id kullanın
            var department = await _httpClient.GetFromJsonAsync<DoctorCommentEntity>($"{_apiDComment}/{id}");
            if (department == null)
            {
                return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Silme işlemi için HTTP DELETE isteği gönderin
            var response = await _httpClient.DeleteAsync($"{_apiDComment}/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla silindi.";
                return RedirectToAction(nameof(GetDoctorComment)); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
            }
            else
            {
                ViewBag.Message = "Departman silinemedi.";
                return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
            }
        }





    }

}