using Cms.Data.Models.Entities;
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
    }
}
