using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Admin.DTOs
{
    public class AppointmentUpdateDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }


        [Required]
        public int DoctorCategoryId { get; set; }
    }
}
