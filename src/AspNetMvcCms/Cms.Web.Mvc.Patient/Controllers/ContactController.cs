using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Security.Claims;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiContact = "https://localhost:7188/api/Contact";

        public ContactController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(ContactEntity entity)
        {
            if (!ModelState.IsValid)
            {
               BadRequest();
            }

         
            // AppointmentEntity'yi oluştur
            var ContactEntity = new ContactEntity
            {
                Fullname = entity.Fullname,
                Phone = entity.Phone,
                Email = entity.Email,
                Text = entity.Text,
                Topic = entity.Topic,
            };

            // Randevu oluşturmayı API'ye gönder
            var response = await _httpClient.PostAsJsonAsync(_apiContact, ContactEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Randevu Başarıyla Oluşturuldu.";
            }
            else
            {
                ViewBag.Error = "Randevu oluşturulurken bir hata oluştu.";
            }

            return View(entity);
        }

    }
}
