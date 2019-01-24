using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentGateway:CommonGateway
    {
        //REGISTER STUDENT
        // save student in database
        public int RegisterStudent(Student student)
        {
            Connection.Open();

            string query =
                "INSERT INTO Student VALUES (@regNo, @name, @email, @contactNo, @date, @address, @departmentId, @year)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@regNo", student.RegNo);
            Command.Parameters.AddWithValue("@name", student.Name);
            Command.Parameters.AddWithValue("@email", student.Email);
            Command.Parameters.AddWithValue("@contactNo", student.ContactNo);
            Command.Parameters.AddWithValue("@date", student.Date);
            Command.Parameters.AddWithValue("@address", student.Address);
            Command.Parameters.AddWithValue("@departmentId", student.DepartmentId);
            Command.Parameters.AddWithValue("@year", student.Year);

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowsAffected;
        }

        // check email is Exists or not
        public bool EmailIsExists(string email)
        {
            Connection.Open();

            string query = "SELECT * FROM Student WHERE Email = @email";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@email", email);

            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;
        }

        //get number of Students by department for regNo
        public int GetNumberOfStudent(int departmentId, string year)
        {
            Connection.Open();

            string query = "SELECT COUNT(*) AS Total FROM Student WHERE DepartmentId = @departmentId AND Year = @year";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@departmentId", departmentId);
            Command.Parameters.AddWithValue("@year", year);

            Reader = Command.ExecuteReader();
            int total = 0;

            while (Reader.Read())
            {
                total = Convert.ToInt32(Reader["Total"]);
            }

            Reader.Close();
            Connection.Close();

            return total;
        }

        // get student information
        public StudentRegInfoViewModel GetStudentInfo(string date)
        {
            Connection.Open();

            string query = "SELECT Student.RegNo AS RegNo, Student.Name AS Name, Student.Email AS Email, Student.ContactNo AS ContactNo, Student.Date AS Date, Student.Address AS Address, Department.Name AS Department FROM Student JOIN Department ON Student.DepartmentId = Department.Id WHERE Student.Date = @date";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@date", date);

            Reader = Command.ExecuteReader();
            
            StudentRegInfoViewModel model = null;

            while(Reader.Read())
            {
                model = new StudentRegInfoViewModel();

                model.RegNo = Reader["RegNo"].ToString();
                model.Name = Reader["Name"].ToString();
                model.Email = Reader["Email"].ToString();
                model.ContactNo = Reader["ContactNo"].ToString();
                model.Address = Reader["Address"].ToString();
                model.Date = Reader["Date"].ToString();
                model.Department = Reader["Department"].ToString();

            }

            Reader.Close();
            Connection.Close();

            return model;
        }

        // ENROLL COURSE
        // get all student registration number
        public List<Student> GetAllStudent()
        {
            Connection.Open();

            string query = "SELECT * FROM Student";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();

            while (Reader.Read())
            {
                Student student = new Student();

                student.Id = Convert.ToInt32(Reader["Id"]);
                student.RegNo = Reader["RegNo"].ToString();
                student.Name = Reader["Name"].ToString();
                student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
               
                students.Add(student);
            }

            Reader.Close();
            Connection.Close();

            return students;
        }
 
        // get Student by Id
        public StudentViewModel GetStudentById(int studentId)
        {
            Connection.Open();

            string query = "SELECT Student.Name AS Name, Student.Email AS Email, Department.Name AS Department FROM Student JOIN Department ON Student.DepartmentId = Department.Id WHERE Student.Id = @id";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@id", studentId);

            Reader = Command.ExecuteReader();
            
            Reader.Read();
            StudentViewModel student = null;

            if (Reader.HasRows)
            {
                student = new StudentViewModel();

                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.DepartmentName = Reader["Department"].ToString();

            }

            Reader.Close();
            Connection.Close();

            return student;
        }

        // get department id by student id
        public int GetDepartmentIdByStudentId(int id)
        {
            Connection.Open();

            string query = "SELECT DepartmentId FROM Student WHERE Id = @id";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@id", id);

            Reader = Command.ExecuteReader();

            Reader.Read();
            int departmentId = 0;

            if (Reader.HasRows)
            {
                departmentId = Convert.ToInt32(Reader["DepartmentId"]);
            }

            Reader.Close();
            Connection.Close();

            return departmentId;
        }

        // enroll course to students
        public int EnrollCourse(EnrollStudent enroll)
        {
            Connection.Open();

            string query =
                "INSERT INTO EnrollStudent VALUES (@studentId, @courseId, @date, @type)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@studentId", enroll.StudentId);
            Command.Parameters.AddWithValue("@courseId", enroll.CourseId);
            Command.Parameters.AddWithValue("@date", enroll.Date);
            Command.Parameters.AddWithValue("@type", "ENROLLED");

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowsAffected;
        }

        // previously enrolled or not
        public bool IsEnrolled(EnrollStudent enroll)
        {
            Connection.Open();

            string query = "SELECT * FROM EnrollStudent WHERE StudentId = @studentId AND CourseId = @courseId AND Type = 'ENROLLED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@studentId", enroll.StudentId);
            Command.Parameters.AddWithValue("@courseId", enroll.CourseId);

            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;
        }


        // SAVE STUDENT RESULT

        // save result
        public int SaveResult(Result result)
        {
            Connection.Open();

            string query = "INSERT INTO Result VALUES (@studentId, @courseId, @gradeId, @type)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@studentId", result.StudentId);
            Command.Parameters.AddWithValue("@courseId", result.CourseId);
            Command.Parameters.AddWithValue("@gradeId", result.GradeId);
            Command.Parameters.AddWithValue("@type", "ASSIGNED");

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowsAffected;
        }

        // check result already exists or not
        public bool IsResultExists(Result result)
        {
            Connection.Open();

            string query = "SELECT * FROM Result WHERE StudentId = @studentId AND CourseId = @courseId AND Type = 'ASSIGNED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@studentId", result.StudentId);
            Command.Parameters.AddWithValue("@courseId", result.CourseId);

            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;
        }

        // update result if exists
        public int UpdateResult(Result result)
        {
            Connection.Open();

            string query = "UPDATE Result SET GradeId = @gradeId WHERE StudentId = @studentId AND CourseId = @courseId AND Type = 'ASSIGNED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@studentId", result.StudentId);
            Command.Parameters.AddWithValue("@courseId", result.CourseId);
            Command.Parameters.AddWithValue("@gradeId", result.GradeId);

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowsAffected;
        }

        // get all enrolled course by student id
        public List<Course> GetAllEnrolledCourseByStudentId(int studentId)
        {
            Connection.Open();

            string query =
                "SELECT Course.Id AS Id, Course.Code AS Code, Course.Name AS Name FROM Course JOIN EnrollStudent ON EnrollStudent.CourseId = Course.Id WHERE EnrollStudent.StudentId = @studentId AND EnrollStudent.Type = 'ENROLLED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@studentId", studentId);

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
 
        // VIEW STUDENT RESULT
        public List<ResultViewModel> GetResultByStudentId(int studentId)
        {
            Connection.Open();

            string query =
                "SELECT Course.Code AS Code, Course.Name AS Name, Grade.GradeLetter AS Grade FROM Course JOIN EnrollStudent ON Course.Id = EnrollStudent.CourseId AND EnrollStudent.StudentId = @studentId AND EnrollStudent.Type = 'ENROLLED' LEFT JOIN Result ON EnrollStudent.CourseId = Result.CourseId AND Result.StudentId = @studentId AND Result.Type='ASSIGNED' LEFT JOIN Grade ON Result.GradeId = Grade.Id";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@studentId", studentId);

            Reader = Command.ExecuteReader();
            List<ResultViewModel> resultViewModels = new List<ResultViewModel>();

            while (Reader.Read())
            {
                ResultViewModel resultViewModel = new ResultViewModel();

                resultViewModel.Code = Reader["Code"].ToString();
                resultViewModel.Name = Reader["Name"].ToString();

                if (Reader["Grade"].ToString().Equals(""))
                {
                    resultViewModel.Grade = "Not Graded Yet";
                }
                else
                {
                    resultViewModel.Grade = Reader["Grade"].ToString();
                }


                resultViewModels.Add(resultViewModel);
            }

            Reader.Close();
            Connection.Close();

            return resultViewModels;
        }

        // get Student by Id for pdf result
        public ResultStudentInfoViewModel GetStudentByIdForPdf(int studentId)
        {
            Connection.Open();

            string query = "SELECT Student.RegNo AS RegNo, Student.Name AS Name, Student.Email AS Email, Department.Name AS Department FROM Student JOIN Department ON Student.DepartmentId = Department.Id WHERE Student.Id = @id";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@id", studentId);

            Reader = Command.ExecuteReader();

            Reader.Read();
            ResultStudentInfoViewModel student = null;

            if (Reader.HasRows)
            {
                student = new ResultStudentInfoViewModel();

                student.RegNo = Reader["RegNo"].ToString();
                student.StudentName = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.Department = Reader["Department"].ToString();

            }

            Reader.Close();
            Connection.Close();

            return student;
        }
    }
}