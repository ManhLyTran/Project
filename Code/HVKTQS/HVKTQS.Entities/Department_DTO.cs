using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.Entities
{
    public class Department_DTO
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public int ViewOrder { get; set; }
    }
}