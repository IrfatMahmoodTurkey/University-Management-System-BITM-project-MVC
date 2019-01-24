using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class HomeGateway:CommonGateway
    {
        // get total department
        public int GetTotalDepartment()
        {
            Connection.Open();

            string query = "SELECT COUNT(*) AS Total FROM Department";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            Reader.Read();
            int total = 0;

            if (Reader.HasRows)
            {
                total = Convert.ToInt32(Reader["Total"]);
            }

            Reader.Close();
            Connection.Close();

            return total;
        }

        //get total teachers
        public int GetTotalTeacher()
        {
            Connection.Open();

            string query = "SELECT COUNT(*) AS Total FROM Teacher";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            Reader.Read();
            int total = 0;

            if (Reader.HasRows)
            {
                total = Convert.ToInt32(Reader["Total"]);
            }

            Reader.Close();
            Connection.Close();

            return total;
        }

        // get total registered student
        public int GetTotalRegisteredStudent()
        {
            Connection.Open();

            string query = "SELECT COUNT(*) AS Total FROM Student";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            Reader.Read();
            int total = 0;

            if (Reader.HasRows)
            {
                total = Convert.ToInt32(Reader["Total"]);
            }

            Reader.Close();
            Connection.Close();

            return total;
        }

        // get total classrooms
        public int GetTotalClassrooms()
        {
            Connection.Open();

            string query = "SELECT COUNT(*) AS Total FROM Room";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            Reader.Read();
            int total = 0;

            if (Reader.HasRows)
            {
                total = Convert.ToInt32(Reader["Total"]);
            }

            Reader.Close();
            Connection.Close();

            return total;
        }

        //get student by department
        public List<StudentByYearViewModel> GetNoOfStudentByYear()
        {
            Connection.Open();

            string query = "SELECT Year, COUNT(*) AS Registered FROM Student GROUP BY Year ORDER BY Year DESC";
            Command = new SqlCommand(query, Connection);
            List<StudentByYearViewModel> students = new List<StudentByYearViewModel>();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                StudentByYearViewModel student = new StudentByYearViewModel();

                student.Year = Reader["Year"].ToString();
                student.StudentNo = Convert.ToInt32(Reader["Registered"]);

                students.Add(student);
            }

            Reader.Close();
            Connection.Close();


            return students;
        } 

        // get teacher info
        public List<TeacherInfoHomeViewModel> GetTeacherInfo()
        {
            Connection.Open();

            string query = "SELECT Teacher.Name AS Name, Teacher.Email AS Email, Teacher.Address AS Address, Teacher.ContactNo AS Phone, Designation.DesignationName AS Designation, Department.Name AS Department, Teacher.CreditTaken AS Credit FROM Teacher JOIN Designation ON Teacher.DesignationId = Designation.Id JOIN Department ON Teacher.DepartmentId = Department.Id";
            Command = new SqlCommand(query, Connection);
            List<TeacherInfoHomeViewModel> teachers = new List<TeacherInfoHomeViewModel>();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                TeacherInfoHomeViewModel teacher = new TeacherInfoHomeViewModel();

                teacher.Name = Reader["Name"].ToString();
                teacher.Email = Reader["Email"].ToString();
                teacher.Address = Reader["Address"].ToString();
                teacher.Phone = Reader["Phone"].ToString();
                teacher.Designation = Reader["Designation"].ToString();
                teacher.Department = Reader["Department"].ToString();
                teacher.CreditTaken = Reader["Credit"].ToString();

                teachers.Add(teacher);
            }

            Reader.Close();
            Connection.Close();


            return teachers;
        }
 
        // get all student info
        public List<StudentInfoHomeViewModel> GetAllStudentInfo()
        {
            Connection.Open();

            string query = "SELECT Student.RegNo AS RegNo, Student.Name AS Name, Student.Email AS Email, Student.ContactNo AS Phone, Student.Date AS Date, Department.Name AS Department FROM Student JOIN Department ON Student.DepartmentId = Department.Id ORDER BY Student.DepartmentId";
            Command = new SqlCommand(query, Connection);
            List<StudentInfoHomeViewModel> students = new List<StudentInfoHomeViewModel>();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                StudentInfoHomeViewModel student = new StudentInfoHomeViewModel();

                student.RegNo = Reader["RegNo"].ToString();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.Phone = Reader["Phone"].ToString();
                student.Date = Reader["Date"].ToString();
                student.Department = Reader["Department"].ToString();

                students.Add(student);
            }

            Reader.Close();
            Connection.Close();


            return students;
        } 
    }
}