using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class DoctorCommentUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
