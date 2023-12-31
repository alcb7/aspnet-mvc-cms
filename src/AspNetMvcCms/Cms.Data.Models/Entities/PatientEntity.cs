﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Models.Entities
{
    public class PatientEntity
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
		[DataType(DataType.EmailAddress)]

		public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        
        [Phone]
		[DataType(DataType.PhoneNumber)]
		public string? Phone { get; set; }

        //public ICollection<AppointmentEntity> Appointments { get; set; }


        public string? Address { get; set; } = string.Empty;
        //public string ResimDosyaAdi { get; set; } // Resim dosya adını burada saklayabilirsiniz.

        //public string ResimYolu
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(ResimDosyaAdi))
        //        {
        //            return "/images/" + ResimDosyaAdi; // wwwroot klasöründeki images altındaki dosyaya göre yol belirtilir.
        //        }
        //        return null;
        //    }
        //}

        public List<PatientCommentEntity>? PatientComments { get; set; }
    }
}
