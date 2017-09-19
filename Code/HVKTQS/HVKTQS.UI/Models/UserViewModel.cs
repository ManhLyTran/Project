using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class UserViewModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string LastIPAddress { get; set; }

        public bool? IsLock { get; set; }

        public virtual EmployeeViewModel Employees { get; set; }

        public virtual IEnumerable<EventUserViewModel> EventUsers { get; set; }
    }
}