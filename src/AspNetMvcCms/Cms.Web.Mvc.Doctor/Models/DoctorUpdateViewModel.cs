using Cms.Data.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Doctor.Models
{
    public class DoctorUpdateViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int CategoryId { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        [Phone]
        public string? Phone { get; set; } = string.Empty;


        

        

        public string? Address { get; set; } = string.Empty;
    

        
        public string? Cv { get; set; } = string.Empty;

        public IFormFile ResimDosyaAdi { get; set; }
    }
}
