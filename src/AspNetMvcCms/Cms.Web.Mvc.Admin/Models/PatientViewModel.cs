using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Admin.Models
{
	public class PatientViewModel
	{
		public int Id { get; set; }

	
		public string Name { get; set; } = string.Empty;

		public string Surname { get; set; } = string.Empty;

		

		public string Email { get; set; } = string.Empty;
	}
}
