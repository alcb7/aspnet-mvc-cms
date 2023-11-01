using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Admin.Models
{
    public class DoctorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        [StringLength(255, ErrorMessage = "İsim en fazla 255 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim zorunludur.")]
        [StringLength(255, ErrorMessage = "Soyisim en fazla 255 karakter olmalıdır.")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
        [Required]
       
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        public string Password { get; set; }

        [Phone]
        public string? Phone { get; set; } = string.Empty;




        //public ICollection<AppointmentEntity> Appointments { get; set; }

        public string? Address { get; set; } = string.Empty;



        public string? Cv { get; set; } = string.Empty;
    }
}
