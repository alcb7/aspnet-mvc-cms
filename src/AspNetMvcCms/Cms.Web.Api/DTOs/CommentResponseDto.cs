using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class CommentResponseDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int BlogId { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
}
