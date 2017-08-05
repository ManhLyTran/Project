using HVKTQS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model
{
    [Table("EventNote")]
    public partial class EventNote : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        public int? EventID { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }
    }
}