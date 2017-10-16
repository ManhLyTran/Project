using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.Entities
{
    public partial class UserExtension_DTO : Employee_DTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastIPAddress { get; set; }
        public bool? IsLock { get; set; }
    }
}