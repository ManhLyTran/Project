using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class EventUserViewModel
    {
        public int EventID { get; set; }

        public int UserID { get; set; }

        public int? Status { get; set; }

        public DateTime ActionDate { get; set; }

        public DateTime ReadDate { get; set; }

        public bool? IsPermissonModify { get; set; }

        public bool? IsRead { get; set; }

        public virtual EventViewModel Event { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}