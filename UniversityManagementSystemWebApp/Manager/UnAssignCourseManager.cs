using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;

namespace UniversityManagementSystemWebApp.Manager
{
    public class UnAssignCourseManager
    {
        private UnAssignAllCourseGateway unAssignAllCourseGateway;

        public UnAssignCourseManager()
        {
            unAssignAllCourseGateway = new UnAssignAllCourseGateway();
        }

        public string UnAssignAllCourse()
        {
            int rowsAffectedTeacher = unAssignAllCourseGateway.UnassignCourseToTeacher();
            int rowsAffectedEnroll = unAssignAllCourseGateway.UnAssignCourseFromEnroll();
            int rowsAffectedResult = unAssignAllCourseGateway.UnAssignResult();

            if (rowsAffectedTeacher > 0 && rowsAffectedEnroll > 0 && rowsAffectedResult > 0)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }

        }
    }
}