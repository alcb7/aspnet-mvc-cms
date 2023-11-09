namespace Cms.Web.Api.DTOs
{
    public class CommentCreateDto
    {
        public string Text { get; set; }
        public int BlogId { get; set; }

        public int PatientId { get; set; }
    }
}
