using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HVKTQS.Model.Models;
using HVKTQS.UI.Models;

namespace HVKTQS.UI.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateDepartment(this Department department, DepartmentViewModel departmentVm)
        {
            department.DepartmentID = departmentVm.DepartmentID;
            department.DepartmentName = departmentVm.DepartmentName;
            department.Description = departmentVm.Description;
            department.ViewOrder = departmentVm.ViewOrder;
        }

        public static void UpdatePosition(this Position position, PositionViewModel positionVm)
        {
            position.PositionID = positionVm.PositionID;
            position.PositionName = positionVm.PositionName;
            position.ViewOrder = positionVm.ViewOrder;
        }

        public static void UpdateSubject(this Subject subject, SubjectViewModel subjectVm)
        {
            subject.SubjectID = subjectVm.SubjectID;
            subject.SubjectName = subjectVm.SubjectName;
            subject.Description = subjectVm.Description;
            subject.DepartmentID = subjectVm.DepartmentID;
            subject.ViewOrder = subjectVm.ViewOrder;
        }
    }
}