using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.Models
{
    public class LoginModel
    {
        [Required, MinLength(1)]
        public string Name { get; set; } = string.Empty;

        [Required, MinLength(1)]
        public string Password { get; set; } = string.Empty;
    }
}
