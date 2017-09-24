using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.Model.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? Sex { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        public int? PositionID { get; set; }

        public int? SubjectID { get; set; }

        [ForeignKey("PositionID")]
        public virtual Position Positions { get; set; }

        [ForeignKey("SubjectID")]
        public virtual Subject Subjects { get; set; }

        public virtual ApplicationUser Users { get; set; }
    }
}