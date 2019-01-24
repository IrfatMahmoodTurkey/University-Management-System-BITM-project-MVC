using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseGateway:CommonGateway
    {
        // SAVE COURSE
        // save course in database
        public int Save(Course course)
        {
            Connection.Open();

            string query = "INSERT INTO Course VALUES (@code, @name, @credit, @description, @departmentId, @semesterId)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@code", course.Code);
            Command.Parameters.AddWithValue("@name", course.Name);
            Command.Parameters.AddWithValue("@credit", course.Credit);
            Command.Parameters.AddWithValue("@description", course.Description);
            Command.Parameters.AddWithValue("@departmentId", course.DepartmentId);
            Command.Parameters.AddWithValue("@semesterId", course.SemesterId);


            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowsAffected;
        }

        // check course name or code is exists or not in database
        public bool CheckCodeNameIsExists(Course course)
        {
            Connection.Open();

            string query = "SELECT * FROM Course WHERE Code = @code OR Name = @name";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@code", course.Code);
            Command.Parameters.AddWithValue("@name", course.Name);

            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExists;
        }

        // get course by department id
        public List<Course> GetAllCoursesByDepartmentId(int departmentId)
        {
            Connection.Open();

            string query = "SELECT * FROM Course WHERE DepartmentId = @departmentId";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@departmentId", departmentId);

            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course course = new Course();

                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                

                courses.Add(course);
            }

            Reader.Close();
            Connection.Close();

            return courses;
        } 

        // get course by course id
        public Course GetCourseByCourseId(int courseId)
        {
            Connection.Open();

            string query = "SELECT * FROM Course WHERE Id = @courseId";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@courseId", courseId);

            Reader = Command.ExecuteReader();

            Course course = null;
            Reader.Read();

            if (Reader.HasRows)
            {
                course = new Course();

                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                course.Credit = Convert.ToDecimal(Reader["Credit"]);

            }

            Reader.Close();
            Connection.Close();

            return course;
        }

        // FOR VIEW COUSE STATICS
        // retrive course with teacher assigned by department
        public List<ViewCourseStaticsViewModel> GetAllCourseWithTeacherAssigned(int departmentId)
        {
            Connection.Open();

            string query =
                "SELECT Course.Code AS CourseCode, Course.Name AS CourseName, Semester.SemesterName AS Semester, Teacher.Name AS AssignTo FROM Course LEFT JOIN AssignCourseToTeacher ON Course.Id = AssignCourseToTeacher.CourseId AND AssignCourseToTeacher.Type='ASSIGNED' LEFT JOIN Teacher ON Teacher.Id = AssignCourseToTeacher.TeacherId LEFT JOIN Semester ON Semester.Id = Course.SemesterId WHERE Course.DepartmentId = @departmentId";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@departmentId", departmentId);

            Reader = Command.ExecuteReader();
            List<ViewCourseStaticsViewModel> courseStaticsViewModels = new List<ViewCourseStaticsViewModel>();

            while (Reader.Read())
            {
                ViewCourseStaticsViewModel viewCourseStaticsViewModel = new ViewCourseStaticsViewModel();

                viewCourseStaticsViewModel.CourseCode = Reader["CourseCode"].ToString();
                viewCourseStaticsViewModel.CourseName = Reader["CourseName"].ToString();
                viewCourseStaticsViewModel.SemesterName = Reader["Semester"].ToString();
                string assignTo = Reader["AssignTo"].ToString();

                if (assignTo.Equals(""))
                {
                    viewCourseStaticsViewModel.AssignTo = "Not Assigned";
                }
                else
                {
                    viewCourseStaticsViewModel.AssignTo = Reader["AssignTo"].ToString();
                }

                courseStaticsViewModels.Add(viewCourseStaticsViewModel);
            }

            Reader.Read();
            Connection.Close();

            return courseStaticsViewModels;
        } 
    }
}