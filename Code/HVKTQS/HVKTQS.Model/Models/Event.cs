using HVKTQS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model
{
    [Table("Event")]
    public partial class Event : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }

        public int? OriginalEventId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public bool? IsImportant { get; set; }

        public bool? IsDone { get; set; }

        public int? SubjectID { get; set; }

        public int? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Departments { get; set; }

        [ForeignKey("SubjectID")]
        public virtual Subject Subjects { get; set; }

        public virtual IEnumerable<EventUser> EventUsers { set; get; }

        public virtual IEnumerable<EventFile> EventFiles { get; set; }

        public virtual IEnumerable<EventNote> EventNotes { get; set; }
    }
}