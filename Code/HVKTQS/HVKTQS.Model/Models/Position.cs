using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model
{
    [Table("Position")]
    public partial class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionID { get; set; }

        [Required]
        [StringLength(255)]
        public string PositionName { get; set; }

        public int? ViewOrder { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}