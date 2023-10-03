using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Web.Mvc.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DoctorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var doctorsWithCategories = _appDbContext.Doctors
           .Include(d => d.Category)
           .ToList();

            return View(doctorsWithCategories);
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
