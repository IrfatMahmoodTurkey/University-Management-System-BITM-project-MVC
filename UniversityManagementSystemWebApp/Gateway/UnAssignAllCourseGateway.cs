using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class UnAssignAllCourseGateway:CommonGateway
    {
        // UNASSIGN ALL COURSES
        // unassigned course to teacher
        public int UnassignCourseToTeacher()
        {
            Connection.Open();

            string query = "UPDATE AssignCourseToTeacher SET Type = 'UNASSIGNED'";
            Command = new SqlCommand(query, Connection);

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowsAffected;
        }


        // un assigned course from enrolled student
        public int UnAssignCourseFromEnroll()
        {
            Connection.Open();

            string query = "UPDATE EnrollStudent SET Type = 'UNENROLLED'";
            Command = new SqlCommand(query, Connection);

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowsAffected;
        }

        // un assign result from result
        public int UnAssignResult()
        {
            Connection.Open();

            string query = "UPDATE Result SET Type = 'UNASSIGNED'";
            Command = new SqlCommand(query, Connection);

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowsAffected;
        }

    }
}