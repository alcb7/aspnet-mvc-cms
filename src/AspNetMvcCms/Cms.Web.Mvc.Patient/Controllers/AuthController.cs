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
using System.Net.Mail;
using System.Net;

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
                ViewBag.Error = "Password and Email Required ";
                return View("Login"); // "Login" eylemine yönlendirmek yerine aynı sayfada kalın
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
		[HttpGet]
		public IActionResult ResetPassword()
		{
			return View();
		}
		
        [HttpPost]
		public async Task<IActionResult> ResetPassword([FromForm] ResetViewModel register)
		{


			var model = await _httpClient.GetFromJsonAsync<List<PatientEntity>>(_apiUrl);
			if (model != null)
			{
				var patient = model.FirstOrDefault(p => p.Email == register.Email);
				if (patient != null)
				{
					Guid random = Guid.NewGuid();
					patient.Password = random.ToString().Substring(0, 8);
					SmtpClient smtpClient = new SmtpClient();
					smtpClient.Credentials = new NetworkCredential("canbulanhospital@gmail.com", "kffj rjhh qkyw qema");
					smtpClient.Port = 587;
					smtpClient.Host = "smtp.gmail.com";
					smtpClient.EnableSsl = true;
					MailMessage message = new MailMessage();
					message.To.Add(register.Email);
					message.From = new MailAddress("canbulanhospital@gmail.com", "Şifre Yenileme");
					message.IsBodyHtml = true;
					message.Subject = "Şifre Sıfırlama";
					message.Body += "Merhaba Sayın" + patient.Name + "<br/> Kullanıcı Adınız =" + patient.Name + "<br/> Şifreniz=" + patient.Password;
					try
					{
						smtpClient.Send(message);
						var response = await _httpClient.PostAsJsonAsync(_apiUrl, patient);

						return RedirectToAction("Index", "Home");

					}
					catch (Exception ex)
					{
						throw;
					}


				}

			}
			return View();
		}

	}
}
