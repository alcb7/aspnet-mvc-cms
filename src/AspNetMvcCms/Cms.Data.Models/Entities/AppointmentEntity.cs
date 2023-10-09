using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Models.Entities
{
    public class AppointmentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime DateTime { get; set; }
       
        //[ForeignKey(nameof(DoctorId))]
        public DoctorEntity? Doctor { get; set; }

        //[ForeignKey(nameof(PatientId))]
        public PatientEntity? Patient { get; set; }





    }
}
