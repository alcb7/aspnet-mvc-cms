using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
