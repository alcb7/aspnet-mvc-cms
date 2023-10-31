using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Models.Entities
{
	public class PatientCommentEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int PatientId { get; set; }
		public string Title { get; set; }

		public string Description { get; set; }

		[ForeignKey(nameof(PatientId))]
		public PatientEntity? Patient { get; set; }
	}
}
