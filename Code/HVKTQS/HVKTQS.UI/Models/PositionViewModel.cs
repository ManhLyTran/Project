using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class PositionViewModel
    {
        public int PositionID { get; set; }

        public string PositionName { get; set; }

        public int? ViewOrder { get; set; }

        public virtual ICollection<EmployeeViewModel> Employees { get; set; }
    }
}