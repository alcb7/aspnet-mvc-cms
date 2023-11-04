using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class AdminUpdateDto
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
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; } = string.Empty;


        public string? Address { get; set; } = string.Empty;



        public string? Cv { get; set; } = string.Empty;
    }
}
