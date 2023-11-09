namespace Cms.Web.Mvc.Patient.Models
{
    public class BlogCommentViewModel
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int PatientId { get; set; }

        public int BlogId { get; set; }
    }
}
