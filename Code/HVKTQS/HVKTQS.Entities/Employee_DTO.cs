using System;

namespace HVKTQS.Entities
{
    public partial class Employee_DTO
    {
        public int EmployeeID { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int PositionID { get; set; }

        public string PositionName { get; set; }

        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public string ImagePath { get; set; }

        public string BachelorDegree { get; set; }

        public string AcademicRank { get; set; }
    }
}