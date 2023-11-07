using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Admin.Models
{
    public class PatientCommentViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        public string Description { get; set; }

        [Required]
        public int PatientId { get; set; }
    }
}
