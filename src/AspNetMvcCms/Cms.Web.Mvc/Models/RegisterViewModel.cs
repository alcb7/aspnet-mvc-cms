using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Models
{
    public class RegisterViewModel
    {
        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(50), MinLength(3)]
        public string Surname { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(4), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string? PasswordVerify { get; set; } = string.Empty;



    }
}
