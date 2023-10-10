using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Models.Entities
{
    public class DoctorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CategoryId { get; set; }

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
        public string Password { get; set; } = string.Empty;

        
        [Phone]
        public string? Phone { get; set; } = string.Empty;


        [ForeignKey(nameof(CategoryId))]
        public DoctorCategoryEntity? Category { get; set; }

        //public ICollection<AppointmentEntity> Appointments { get; set; }

        public string? Address { get; set; } = string.Empty;
        public string? ResimDosyaAdi { get; set; } 

        public string? ResimYolu
        {
            get
            {
                if (!string.IsNullOrEmpty(ResimDosyaAdi))
                {
                    return "/images/" + ResimDosyaAdi; // wwwroot klasöründeki images altındaki dosyaya göre yol belirtilir.
                }
                return null;
            }
        }
        public string? Cv { get; set; } = string.Empty;
    }
}
