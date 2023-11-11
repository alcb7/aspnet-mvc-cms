using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Admin.Models
{
    public class ServiceBlogViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile ResimDosyaAdi { get; set; }

    }
}
