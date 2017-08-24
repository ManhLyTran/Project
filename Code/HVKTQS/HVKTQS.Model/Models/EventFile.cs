using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model.Models
{
    [Table("EventFile")]
    public partial class EventFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventFileID { get; set; }

        [Required]
        public int? EventID { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        public long? FileSize { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        [ForeignKey("EventID")]
        public virtual Event Events { get; set; }
    }
}