using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Api.DTOs
{
    public class AppointmentCreateDto
    {
        [Required]
        public int DoctorId { get; set; }
       
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorCategoryId { get; set; }
    }
}
