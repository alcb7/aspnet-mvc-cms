using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class AppoinmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
