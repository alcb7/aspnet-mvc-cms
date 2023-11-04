using Cms.Data.Models.Entities;

namespace Cms.Web.Mvc.Admin.Models
{
    public class BlogModel
    {
        public List<BlogEntity> blogs { get; set; }
        public List<BlogCategoryEntity> blogcategories { get; set; }
    }
}
