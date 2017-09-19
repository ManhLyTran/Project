using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class SubjectViewModel
    {
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public int? DepartmentID { get; set; }

        public string Description { get; set; }

        public int? ViewOrder { get; set; }

        public virtual DepartmentViewModel Department { set; get; }

        public virtual IEnumerable<UserViewModel> Users { set; get; }

        public virtual IEnumerable<EventViewModel> Events { set; get; }
    }
}