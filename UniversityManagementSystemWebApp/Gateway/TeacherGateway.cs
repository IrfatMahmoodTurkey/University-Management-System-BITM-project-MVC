using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class TeacherGateway:CommonGateway
    {
        // SAVE TEACHER
        // save teacher in database
        public int Save(Teacher teacher)
        {
            Connection.Open();

            string query = "INSERT INTO Teacher VALUES (@name, @address, @email, @contactNo, @designationId, @departmentId, @creditTaken)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@name", teacher.Name);
            Command.Parameters.AddWithValue("@address", teacher.Address);
            Command.Parameters.AddWithValue("@email", teacher.Email);
            Command.Parameters.AddWithValue("@contactNo", teacher.ContactNo);
            Command.Parameters.AddWithValue("@designationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@departmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@creditTaken", teacher.CreditTaken);


            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowsAffected;
        }

        // check teacher email is already exists or not in database
        public bool CheckEmailExists(string email)
        {
            Connection.Open();

            string query = "SELECT * FROM Teacher WHERE Email = @email";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@email", email);

            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExists;
        }


        // For ASSIGN COURSE TO TEACHER
        // get teacher by departmentId
        public List<Teacher> GetAllTeachersByDepartment(int departmentId)
        {
            Connection.Open();

            string query = "SELECT * FROM Teacher WHERE DepartmentId = @departmentId";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@departmentId", departmentId);

            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();

            while (Reader.Read())
            {
                Teacher teacher = new Teacher();

                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.Name = Reader["Name"].ToString();
                
                teachers.Add(teacher);
            }

            Reader.Close();
            Connection.Close();

            return teachers;
        }
 
        // get teacher info by teacher id
        public Teacher GetTeacherByTeacherId(int teacherId)
        {
            Connection.Open();

            string query = "SELECT * FROM Teacher WHERE Id = @teacherId";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@teacherId", teacherId);

            Reader = Command.ExecuteReader();

            Teacher teacher = null;
            Reader.Read();

            if(Reader.HasRows)
            {
                teacher = new Teacher();

                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.Name = Reader["Name"].ToString();
                teacher.CreditTaken = Convert.ToDecimal(Reader["CreditTaken"]);

            }

            Reader.Close();
            Connection.Close();

            return teacher;
        }

        // get total credit taken by teacher
        public decimal GetTotalCourseCreditTakenByTeacher(int teacherId)
        {
            Connection.Open();

            string query =
                "SELECT SUM(Course.Credit) AS TotalCredit FROM AssignCourseToTeacher JOIN Course ON AssignCourseToTeacher.CourseId = Course.Id WHERE AssignCourseToTeacher.TeacherId = @teacherId AND Type='ASSIGNED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@teacherId", teacherId);

            Reader = Command.ExecuteReader();

            Reader.Read();

            decimal totalCredit = 0.0m;

            if (Reader.HasRows)
            {
                var credit = Reader["TotalCredit"].ToString();
                if (credit!="")
                {
                    totalCredit = Convert.ToDecimal(Reader["TotalCredit"]);
                }
            }

            Reader.Close();
            Connection.Close();

            return totalCredit;
        }

        // check course assigned or not
        public bool IsAssigned(AssignCourseToTeacher assignCourse)
        {
            Connection.Open();

            string query = "SELECT * FROM AssignCourseToTeacher WHERE CourseId = @courseId AND Type = 'ASSIGNED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@courseId", assignCourse.CourseId);

            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExists;
        }

        //assign course to teacher (Save in AssignCourseTable)
        public int CourseAssign(AssignCourseToTeacher assignCourse)
        {
            Connection.Open();

            string query = "INSERT INTO AssignCourseToTeacher VALUES (@teacherId, @courseId, @type)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@teacherId", assignCourse.TeacherId);
            Command.Parameters.AddWithValue("@courseId", assignCourse.CourseId);
            Command.Parameters.AddWithValue("@type", "ASSIGNED");


            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowsAffected; 
        }
    }
}