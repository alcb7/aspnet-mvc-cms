//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using Cms.Data.Models.Entities;

//namespace Cms.Web.Mvc.Patient.Controllers
//{


//    public class AuthController : Controller
//    {
//        private readonly string _apiUrl = "www.XNXX.com";
//        private readonly HttpClient _httpClient; // Client

//        public AuthController(IDataRepository<PatientEntity> patientRepository)
//        {
//            _patientRepository = patientRepository;
//        }

//        [HttpGet("login")]
//        public async Task<IActionResult> Login(DoctorEntity entity)
//        {

//            List<DoctorEntity> model = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiUrl);

//            DoctorEntity mainModel = model.Where(d=> d.Password == entity.Password ).FirstOrDefault()
//            return View();
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromForm] LoginViewModel login)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var user = await _patientRepository.GetAll()
//                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);


//            if (user == null)
//            {
//                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
//                return View(login);
//            }

//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, user.Name),
//                new Claim(ClaimTypes.Surname, user.Surname),
//                new Claim(ClaimTypes.Email, user.Email),
//                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
//            };

//            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

//            var authProperties = new AuthenticationProperties
//            {
//                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
//                IsPersistent = login.RememberMe
//            };

//            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

//            return RedirectToAction("Index", "Home");
//        }

//        [HttpGet("logout")]
//        public async Task<IActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return RedirectToAction(nameof(Login));
//        }

//        [AllowAnonymous]
//        [HttpGet("register")]
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [AllowAnonymous]
//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromForm] RegisterViewModel register)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(register);
//            }

//            if (register.Password != register.PasswordVerify)
//            {
//                ViewBag.Error = "Şifreler uyuşmuyor";
//                return View(register);
//            }

//            var user = new UserEntity
//            {
//                Name = register.Name,
//                Surname = register.Surname,
//                Email = register.Email,
//                Password = register.Password
//            };

//            _userRepository.Create(user);

//            ViewBag.Message = "Kullanıcı Başarıyla kaydedildi.";
//            return View();
//        }
//    }
//}

