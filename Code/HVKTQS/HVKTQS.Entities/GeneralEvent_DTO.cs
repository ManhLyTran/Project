using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.Entities
{
    public class GeneralEvent_DTO
    {
        public int GeneralEventID { get; set; }
        public int OriginalEventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public string Participant { get; set; }
        public string Preparation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDone { get; set; }
        public int SubjectID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string Content { get; set; }
    }
}