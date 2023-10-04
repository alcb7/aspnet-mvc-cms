using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public NavbarViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<NavbarEntity> navbar = _appDbContext.Navbars.ToList();
            return View(navbar);
        }
    }
}
