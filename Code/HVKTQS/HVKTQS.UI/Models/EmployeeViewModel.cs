using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? Sex { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? PositionID { get; set; }

        public int? SubjectID { get; set; }

        public virtual PositionViewModel Positions { get; set; }

        public virtual SubjectViewModel Subjects { get; set; }

        public virtual UserViewModel Users { get; set; }
    }
}