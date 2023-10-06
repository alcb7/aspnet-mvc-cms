
using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiUrl = "https://localhost:7188/api/Navbar";
        public NavbarViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                // API'den doktor verilerini alın.
                var navbars = await _httpClient.GetFromJsonAsync<List<NavbarEntity>>(_apiUrl);

                return View(navbars);
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada ele alınabilir, örneğin hata mesajını bir loga kaydedebilirsiniz.
                // Hata durumunda uygun bir hata sayfasına veya mesaja yönlendirme yapılabilir.
                return Content("Veriler alınamadı: " + ex.Message);
            }
        }
    }
}
