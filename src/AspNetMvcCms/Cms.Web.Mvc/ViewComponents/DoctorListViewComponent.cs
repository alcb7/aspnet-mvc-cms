
using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.ViewComponents
{
    public class DoctorListViewComponent : ViewComponent
    {
      
        private readonly HttpClient _httpClient;

        private readonly string _apiUrl = "https://localhost:7188/api/Doctors";
        public DoctorListViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                // API'den doktor verilerini alın.
                var doctors = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiUrl);

                return View(doctors);
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

