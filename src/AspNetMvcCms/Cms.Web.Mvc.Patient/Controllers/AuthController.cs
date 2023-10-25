using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;
using Cms.Web.Mvc.Patient.Models;

namespace Cms.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly string _apiUrl = "https://localhost:7188/api/Patients";
        private readonly HttpClient _httpClient; // Client

        public AuthController(HttpClient httpClient) // Dependency injection ile HttpClient ekleyin
        {
            _httpClient = httpClient;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Burada kullanıcıyı doğrulamak için API'yi kullanabilirsiniz
            var response = await _httpClient.GetAsync(_apiUrl);

            if (response.IsSuccessStatusCode)
            {
                List<PatientEntity> model = await _httpClient.GetFromJsonAsync<List<PatientEntity>>(_apiUrl);

                var mainModel = model.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

                if (mainModel != null)
                {
                    // Kullanıcı doğrulandı, kimlik bilgilerini oluştur ve oturum aç
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, mainModel.Name),
                new Claim(ClaimTypes.Surname, mainModel.Surname),
                    new Claim(ClaimTypes.PrimarySid, mainModel.Id.ToString())
                // Diğer kimlik bilgilerini burada ekleyebilirsiniz
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = login.RememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Eşleşen doktor bulunamadı, hata mesajı görüntüle
                    ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                    return View(login);
                }
            }
            else
            {
                // API ile iletişim sırasında bir hata oluştu, hata mesajı görüntüle
                ViewBag.Error = "API ile iletişim sırasında bir hata oluştu.";
                return View(login);
            }
        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        [AllowAnonymous]
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (register.Password != register.PasswordVerify)
            {
                ViewBag.Error = "Şifreler uyuşmuyor";
                return View(register);
            }

            var user = new PatientEntity
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                Password = register.Password,
                


            };

            var response = await _httpClient.PostAsJsonAsync(_apiUrl, user);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Kullanıcı Başarıyla kaydedildi.";
            }

            return View();
        }


    }
}
