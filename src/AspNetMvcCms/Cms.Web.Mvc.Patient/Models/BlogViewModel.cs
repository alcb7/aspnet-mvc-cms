using Cms.Data.Models.Entities;

namespace Cms.Web.Mvc.Patient.Models
{
    public class BlogViewModel
    {
        public BlogEntity Blogs { get; set; }
        public List<CommentEntity> Comments { get; set; }

        public int Id { get; set; }
        public string? Text { get; set; }
        public int PatientId { get; set; }

        public int BlogId { get; set; }
    }
}
