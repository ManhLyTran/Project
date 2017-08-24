using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model.Models
{
    [Table("EventUser")]
    public partial class EventUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        public int? Status { get; set; }

        public DateTime ActionDate { get; set; }

        public DateTime ReadDate { get; set; }

        public bool? IsPermissonModify { get; set; }

        public bool? IsRead { get; set; }

        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}