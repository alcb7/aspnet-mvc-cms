using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class BlogCreateDto
    {
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Title { get; set; }
       
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Description { get; set; }

        [Required]
        public int BlogCategoryId { get; set; }

        public string? ResimDosyaAdi { get; set; }
    }
}
