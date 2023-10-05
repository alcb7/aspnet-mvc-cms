using App.Data.Context;
using App.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cms.Web.Mvc.ViewComponents
{
    public class DepartmentListViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentListViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<DepartmentEntity> departmentList = _appDbContext.Department.ToList();

            return View(departmentList);
        }
    }
}
