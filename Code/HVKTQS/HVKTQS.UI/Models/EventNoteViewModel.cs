using HVKTQS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class EventNoteViewModel
    {
        public int NoteId { get; set; }

        public int? EventID { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public virtual EventViewModel Event { get; set; }
    }
}