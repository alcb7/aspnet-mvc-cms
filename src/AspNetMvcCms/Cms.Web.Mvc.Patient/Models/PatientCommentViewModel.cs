using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Patient.Models
{
	public class PatientCommentViewModel
	{
        public int Id { get; set; }

        public string Title { get; set; }

		public string Description { get; set; }

		public int PatientId { get; set; }
        
    }
}
