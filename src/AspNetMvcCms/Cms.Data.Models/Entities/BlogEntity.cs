using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Models.Entities
{
    public class BlogEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int BlogCategoryId { get; set; }
        //public int BlogCommentId { get; set; }

        [ForeignKey(nameof(BlogCategoryId))]
        public BlogCategoryEntity? Category { get; set; }
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
		//[ForeignKey(nameof(BlogCommentId))]
		//public CommentEntity? Comments { get; set; }
        public ICollection<CommentEntity>? Comments { get; set; }

    }
}
