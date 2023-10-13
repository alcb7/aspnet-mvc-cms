using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Doctor.Models
{
	public class LoginViewModel
	{
		[Required, EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required, MinLength(2)]
		public string Password { get; set; } = string.Empty;

		public bool RememberMe { get; set; }
	}
}
