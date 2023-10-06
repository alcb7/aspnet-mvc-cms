using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
