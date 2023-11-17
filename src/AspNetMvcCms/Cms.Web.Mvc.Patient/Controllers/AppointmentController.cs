using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


public class AppointmentController : Controller
{
    private readonly HttpClient _httpClient;

    private readonly string _apiDoctorCategory = "http://api.canbulanhospital.com/api/DoctorCategory";
    private readonly string _apiDoctor = "http://api.canbulanhospital.com/api/Doctors";
    private readonly string _apiAppointment = "http://api.canbulanhospital.com/api/Appointment";

    public AppointmentController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            // Kullanıcı oturum açmışsa randevu sayfasını görüntüle
            var model = await _httpClient.GetFromJsonAsync<List<DoctorCategoryEntity>>(_apiDoctorCategory);
            ViewBag.DepartmentId = new SelectList(model, "Id", "Name");
            return View();
        }
        else
        {
            // Kullanıcı oturum açmamışsa oturum açma sayfasına yönlendir
            return RedirectToAction("Login", "Auth");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Index(AppointmentEntity entity)
    {
        if (!ModelState.IsValid)
        {
            // Geçerli değilse, hata mesajıyla birlikte aynı görünümü döndürün
            var model = await _httpClient.GetFromJsonAsync<List<DoctorCategoryEntity>>(_apiDoctorCategory);
            ViewBag.DepartmentId = new SelectList(model, "Id", "Name");
            return View(entity);
        }

        // Oturum açmış kullanıcının kimlik bilgilerini al
        var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

        // AppointmentEntity'yi oluştur
        var appointmentEntity = new AppointmentEntity
        {
            DoctorCategoryId = entity.DoctorCategoryId,
            DoctorId = entity.DoctorId,
            DateTime = entity.DateTime,
            PatientId = userId // Kullanıcının kimliğini atan
        };

        // Randevu oluşturmayı API'ye gönder
        var response = await _httpClient.PostAsJsonAsync(_apiAppointment, appointmentEntity);

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

    public async Task<JsonResult> LoadDoctor(int categoryId)
    {
        List<DoctorEntity>? doctorlist = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiDoctor);
        List<DoctorEntity>? newDoctors = doctorlist?
            .Where(d => d.CategoryId == categoryId)
            .ToList();

        return Json(new SelectList(newDoctors, "Id", "Name"));
    }
}
