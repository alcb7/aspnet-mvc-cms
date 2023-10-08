using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class BlogUpdateDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Description { get; set; }

        [Required]
        public int BlogCategoryId { get; set; }
    }
}
