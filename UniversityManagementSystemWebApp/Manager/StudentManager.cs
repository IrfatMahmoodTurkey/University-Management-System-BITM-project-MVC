using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;
        private DepartmentGateway departmentGateway;

        public StudentManager()
        {
            studentGateway = new StudentGateway();
            departmentGateway = new DepartmentGateway();
        }

        // save or register student
        public string RegisterStudent(Student student)
        {
            if (studentGateway.EmailIsExists(student.Email))
            {
                return "Exists";
            }
            else
            {
                student.RegNo = MakeRegistrationNumber(student);
                System.Diagnostics.Debug.Write(student.RegNo);

                int rowsAffected = studentGateway.RegisterStudent(student);

                if (rowsAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
        }

        // get student information
        public StudentRegInfoViewModel GetInsertedStudentInfo(string date)
        {
            return studentGateway.GetStudentInfo(date);
        }

        //make registration number
        public string MakeRegistrationNumber(Student student)
        {
            int studentCount = studentGateway.GetNumberOfStudent(student.DepartmentId, student.Year);
            Department department = departmentGateway.GetDepartmentByDepartmentId(student.DepartmentId);
            string regNo = null;
            string year = student.Year;
            string departmentCode = department.Code;

            if (studentCount < 10)
            {
                if (studentCount == 9)
                {
                    int numberPart = studentCount + 1;
                    string numberPartString = "0" + numberPart.ToString();
                    regNo = departmentCode + "-" + year + "-" + numberPartString;

                }
                else
                {
                    int numberPart = studentCount + 1;
                    string numberPartString = "00" + numberPart.ToString();
                    regNo = departmentCode + "-" + year + "-" + numberPartString;
                }
            }
            else if (studentCount < 100 && studentCount >= 10)
            {
                if (studentCount == 99)
                {
                    int numberPart = studentCount + 1;
                    string numberPartString = numberPart.ToString();

                    regNo = departmentCode + "-" + year + "-" + numberPartString;
                }
                else
                {
                    int numberPart = studentCount + 1;
                    string numberPartString = "0" + numberPart.ToString();

                    regNo = departmentCode + "-" + year + "-" + numberPartString;
                }  
            }
            else
            {
                int numberPart = studentCount + 1;
                string numberPartString = numberPart.ToString();

                regNo = departmentCode + "-" + year + "-" + numberPartString;
            }

            return regNo;
        }

        // ENROLL COURSE
        // get all student for dropdown
        public List<SelectListItem> GetAllStudentsForDropDown()
        {
            List<Student> students = studentGateway.GetAllStudent();

            List<SelectListItem> selectListItems = students.ConvertAll(x => new SelectListItem() {Text = x.RegNo, Value = x.Id.ToString()});
            List<SelectListItem> mainSelectListItems = new List<SelectListItem>();

            mainSelectListItems.Add(new SelectListItem(){Value = "", Text = "--Select Student RegNo--"});

            mainSelectListItems.AddRange(selectListItems);

            return mainSelectListItems;
        }
 
        // get student info by id
        public StudentViewModel GetStudentById(int id)
        {
            return studentGateway.GetStudentById(id);
        }
 
        // get department id by student id
        public int GetDepartmentIdByStudentId(int id)
        {
            return studentGateway.GetDepartmentIdByStudentId(id);
        }

        // ENROLL COURSE
        public string EnrollCourse(EnrollStudent enroll)
        {
            if (studentGateway.IsEnrolled(enroll))
            {
                return "Exists";
            }
            else
            {
                int rowsAffected = studentGateway.EnrollCourse(enroll);

                if (rowsAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
        }



        //SAVE STUDENT RESULT
        public string SaveResult(Result result)
        {
            if (studentGateway.IsResultExists(result))
            {
                int rowsAffected = studentGateway.UpdateResult(result);

                if (rowsAffected > 0)
                {
                    return "UpdateSuccess";
                }
                else
                {
                    return "UpdateFailed";
                }
            }
            else
            {
                int rowsAffected = studentGateway.SaveResult(result);

                if (rowsAffected > 0)
                {
                    return "SaveSuccess";
                }
                else
                {
                    return "SaveFailed";
                }
            }
        }

        public List<Course> GetEnrolledCourseByStudentId(int studentId)
        {
            return studentGateway.GetAllEnrolledCourseByStudentId(studentId);
        }
 
        // VIEW STUDENT RESULT
        public List<ResultViewModel> GetResultByStudentId(int studentId)
        {
            return studentGateway.GetResultByStudentId(studentId);
        }
 
        // get Student by Id for pdf result
        public ResultStudentInfoViewModel GetStudentByIdForPdf(int studentId)
        {
            return studentGateway.GetStudentByIdForPdf(studentId);
        }
    }
}