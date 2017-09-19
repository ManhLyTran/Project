using HVKTQS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class EventViewModel
    {
        public int EventID { get; set; }

        public int? OriginalEventId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsImportant { get; set; }

        public bool? IsDone { get; set; }

        public int? SubjectID { get; set; }

        public int? DepartmentID { get; set; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public virtual DepartmentViewModel Departments { get; set; }

        public virtual SubjectViewModel Subjects { get; set; }

        public virtual IEnumerable<EventUserViewModel> EventUsers { set; get; }

        public virtual IEnumerable<EventFileViewModel> EventFiles { get; set; }

        public virtual IEnumerable<EventNoteViewModel> EventNotes { get; set; }
    }
}