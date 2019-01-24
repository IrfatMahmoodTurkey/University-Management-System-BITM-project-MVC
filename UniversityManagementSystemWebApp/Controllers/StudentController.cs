using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentController : Controller
    {
        private DepartmentManager departmentManager;
        private StudentManager studentManager;
        private CourseManager courseManager;
        private GradeManager gradeManager;

        public StudentController()
        {
            departmentManager = new DepartmentManager();
            studentManager = new StudentManager();
            courseManager = new CourseManager();
            gradeManager = new GradeManager();
        }
        //
        // GET: /Student/

        // REGISTER STUDENT

        // action method for RegisterStudent (GET)
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            return View();
        }

        // action method for RegisterStudent (POST)
        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                // for year
                student.Year = student.Date.Substring(6, 4);
                ViewBag.Response = studentManager.RegisterStudent(student);
                ViewBag.StudentInfo = studentManager.GetInsertedStudentInfo(student.Date);
            }
            else
            {
                ViewBag.Response = "Empty";
            }
            
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            ModelState.Clear();

            return View();
        }

        // ENROLL Course
        // action Method for EnrollCourse(GET)
        [HttpGet]
        public ActionResult EnrollCourseForStudents()
        {
            ViewBag.Students = studentManager.GetAllStudentsForDropDown();
            return View();
        }

        // get student info by id
        public JsonResult GetStudentInfoById(int id)
        {
            StudentViewModel student = studentManager.GetStudentById(id);

            return Json(student);
        }

        // get courses by student department
        public JsonResult GetCoursesByStudentDepartment(int id)
        {
            int departmentId = studentManager.GetDepartmentIdByStudentId(id);
            List<Course> courses = courseManager.GetAllCoursesByDepartmentId(departmentId);

            return Json(courses);
        }

        [HttpPost]
        public ActionResult EnrollCourseForStudents(EnrollStudent enroll)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Response = studentManager.EnrollCourse(enroll);      
            }
            else
            {
                ViewBag.Response = "Empty";
            }

            ViewBag.Students = studentManager.GetAllStudentsForDropDown();
            ModelState.Clear();
            return View();
        }
       

        // SAVE STUDENT RESULT
        [HttpGet]
        public ActionResult SaveResult()
        {
            ViewBag.Students = studentManager.GetAllStudentsForDropDown();
            ViewBag.Grades = gradeManager.GetAllGradesForDropDown();
            return View();
        }

        // get student info by student id
        public JsonResult GetStudentInfoByStudentId(int studentId)
        {
            StudentViewModel studentViewModel = studentManager.GetStudentById(studentId);
            return Json(studentViewModel);
        }

        // get enrolled course by studentid
        public JsonResult GetEnrolledCourseByStudentId(int studentId)
        {
            List<Course> enrolledCourses = studentManager.GetEnrolledCourseByStudentId(studentId);
            return Json(enrolledCourses);
        }

        [HttpPost]
        public ActionResult SaveResult(Result result)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Response = studentManager.SaveResult(result);
            }
            else
            {
                ViewBag.Response = "Empty";
            }

            ViewBag.Students = studentManager.GetAllStudentsForDropDown();
            ViewBag.Grades = gradeManager.GetAllGradesForDropDown();

            ModelState.Clear();
            return View();
        }

        // VIEW STUDENT RESULT
        [HttpGet]
        public ActionResult ViewStudentResult()
        {
            ViewBag.Students = studentManager.GetAllStudentsForDropDown();
            return View();
        }

        // get student info by studentId
        public JsonResult GetStudentById(int studentId)
        {
            StudentViewModel studentViewModel = studentManager.GetStudentById(studentId);

            return Json(studentViewModel);
        }

        // get student result by student id
        public JsonResult GetResultByStudentId(int studentId)
        {
            List<ResultViewModel> resultViewModels = studentManager.GetResultByStudentId(studentId);

            return Json(resultViewModels);
        }

        // post for export pdf
        [HttpPost]
        public ActionResult ViewStudentResult(int studentId)
        {
            // go to export pdf action
            ViewBag.Students = studentManager.GetAllStudentsForDropDown();
            return RedirectToAction("ExportPdf","Student", new {studentId = studentId});
        }

        // make pdf
        public ActionResult ExportPdf(int studentId)
        {
            // go to new page( will not show ) and make it pdf
            return new ActionAsPdf("DataShow", new { studentId = studentId })
            {
		        FileName = Server.MapPath("~/Content/FileName.pdf")
	        };;
        }

        // pdf page
        [HttpGet]
        public ActionResult DataShow(int studentId)
        {
            ResultStudentInfoViewModel studentInfo = studentManager.GetStudentByIdForPdf(studentId);
            ViewBag.RegNo = studentInfo.RegNo;
            ViewBag.Name = studentInfo.StudentName;
            ViewBag.Email = studentInfo.Email;
            ViewBag.Department = studentInfo.Department;

            ViewBag.Result = studentManager.GetResultByStudentId(studentId);
            return View();
        }
	}
}