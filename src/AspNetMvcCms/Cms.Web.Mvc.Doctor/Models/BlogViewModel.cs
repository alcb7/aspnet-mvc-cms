using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Doctor.Models
{
	public class BlogViewModel
	{
		[Required]
		public int Id { get; set; }

		[Required(ErrorMessage = "İsim zorunludur.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "İsim zorunludur.")]
		public string Description { get; set; }

		[Required]
		public int BlogCategoryId { get; set; }
	}
}
