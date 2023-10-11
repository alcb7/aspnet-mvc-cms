using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Admin.DTOs
{
    public class BlogCreateDto
    {
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Description { get; set; }

        [Required]
        public int BlogCategoryId { get; set; }
    }
}
