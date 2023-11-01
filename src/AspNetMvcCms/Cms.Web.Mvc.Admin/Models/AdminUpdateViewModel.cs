using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Admin.Models
{
    public class AdminUpdateViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

      
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;




        [Phone]
        public string? Phone { get; set; } = string.Empty;




        //public ICollection<AppointmentEntity> Appointments { get; set; }

        public string? Address { get; set; } = string.Empty;



        public string? Cv { get; set; } = string.Empty;

    }
}
