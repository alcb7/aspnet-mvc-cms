using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Doctor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Doctor.Controllers
{
	public class AuthController : Controller
	{
		private readonly string _apiUrl = "https://api.canbulanhospital.com/api/Doctors";
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
				List<DoctorEntity> model = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiUrl);

				var mainModel = model.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

				if (mainModel != null)
				{
					// Kullanıcı doğrulandı, kimlik bilgilerini oluştur ve oturum aç
					var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, mainModel.Name),
				new Claim(ClaimTypes.Surname, mainModel.Surname),
				new Claim(ClaimTypes.PrimarySid, mainModel.Id.ToString())

                //new Claim(ClaimTypes.Email, mainModel.Email),
                //new Claim(ClaimTypes.MobilePhone, mainModel.Phone),
                //new Claim(ClaimTypes.StreetAddress, mainModel.Address)
              

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
            string otherMvcProjectUrl = "https://doctor.canbulanhospital.com/login";
            return Redirect(otherMvcProjectUrl);
        }





	}
}
