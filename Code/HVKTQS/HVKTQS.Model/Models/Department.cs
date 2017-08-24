using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model.Models
{
    [Table("Department")]
    public partial class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(255)]
        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public int? ViewOrder { get; set; }

        public virtual IEnumerable<Subject> Subjects { set; get; }

        public virtual IEnumerable<Event> Events { set; get; }
    }
}