using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class DepartmentViewModel
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên phòng ban")]
        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public int? ViewOrder { get; set; }

        public virtual IEnumerable<SubjectViewModel> Subjects { set; get; }

        public virtual IEnumerable<EventViewModel> Events { set; get; }
    }
}