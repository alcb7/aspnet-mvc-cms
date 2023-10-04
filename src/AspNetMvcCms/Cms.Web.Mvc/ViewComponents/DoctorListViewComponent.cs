using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.ViewComponents
{
    public class DoctorListViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public DoctorListViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<DoctorEntity> doctor = _appDbContext.Doctors.ToList();
            return View(doctor);
        }
    }
}

