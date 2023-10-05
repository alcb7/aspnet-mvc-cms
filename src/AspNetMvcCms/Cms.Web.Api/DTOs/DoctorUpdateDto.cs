using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class DoctorUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        [StringLength(255, ErrorMessage = "İsim en fazla 255 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim zorunludur.")]
        [StringLength(255, ErrorMessage = "Soyisim en fazla 255 karakter olmalıdır.")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
    }
}
