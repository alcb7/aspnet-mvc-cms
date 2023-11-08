using Cms.Data.Models.Entities;

namespace Cms.Web.Mvc.Patient.Models
{
    public class BlogViewModel
    {
        public BlogEntity Blogs { get; set; }
        public List<CommentEntity> Comments { get; set; }
    }
}
