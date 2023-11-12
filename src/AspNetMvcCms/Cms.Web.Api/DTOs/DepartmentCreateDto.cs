using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class DepartmentCreateDto
    {
        [Required]
        public string Name {  get; set; }

        [Required]
        public string Description { get; set; }
        public string? ResimDosyaAdi { get; set; }

    }
}
