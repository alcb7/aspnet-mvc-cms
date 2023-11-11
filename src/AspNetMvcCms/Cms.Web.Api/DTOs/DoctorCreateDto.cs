using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class DoctorCreateDto
    {
        [Required(ErrorMessage = "İsim zorunludur.")]
        [StringLength(255, ErrorMessage = "İsim en fazla 255 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim zorunludur.")]
        [StringLength(255, ErrorMessage = "Soyisim en fazla 255 karakter olmalıdır.")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
      
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        public string? ResimDosyaAdi { get; set; } // doctor_1.jpg
        public string? Cv { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;

    }
}
