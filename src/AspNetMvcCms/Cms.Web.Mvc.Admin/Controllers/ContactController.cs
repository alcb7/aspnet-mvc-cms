using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiContact = "https://localhost:7188/api/Contact";

        public ContactController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> GetContacts()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ContactEntity>>(_apiContact);
            return View(model);
        }
      
        [HttpPost]
        public async Task<ActionResult> DeleteContacts(int id)
        {
            // İlgili departmanın bilgilerini almak için id kullanın
            var contact = await _httpClient.GetFromJsonAsync<ContactEntity>($"{_apiContact}/{id}");
            if (contact == null)
            {
                return NotFound(); // Departman bulunamadıysa 404 hatası döndürün veya başka bir işlem yapın.
            }

            // Silme işlemi için HTTP DELETE isteği gönderin
            var response = await _httpClient.DeleteAsync($"{_apiContact}/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Departman Başarıyla silindi.";
                return RedirectToAction("GetContacts"); // Departmanlar listesine yönlendirin veya başka bir işlem yapın.
            }
            else
            {
                ViewBag.Message = "Departman silinemedi.";
                return View(); // Silme başarısızsa geri dönün veya başka bir işlem yapın.
            }
        }
    }
}
