using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Models.Entities
{
    public class FileEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }


    }
}
