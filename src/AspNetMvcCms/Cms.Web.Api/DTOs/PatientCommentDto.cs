using Cms.Data.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
	public class PatientCommentDto
	{
		
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		public int PatientId { get; set; }
	}
}
