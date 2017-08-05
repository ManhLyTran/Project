using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model
{
    [Table("Subject")]
    public partial class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }

        [Required]
        [StringLength(255)]
        public string SubjectName { get; set; }

        public int? DepartmentID { get; set; }

        public string Description { get; set; }

        public int? ViewOrder { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { set; get; }

        public virtual IEnumerable<User> Users { set; get; }

        public virtual IEnumerable<Event> Events { set; get; }
    }
}