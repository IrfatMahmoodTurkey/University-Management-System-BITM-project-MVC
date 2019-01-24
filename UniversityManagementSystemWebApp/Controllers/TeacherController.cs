using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private DesignationManager designationManager;
        private DepartmentManager departmentManager;
        private TeacherManager teacherManager;
        private CourseManager courseManager;

        public TeacherController()
        {
            designationManager = new DesignationManager();
            departmentManager = new DepartmentManager();
            teacherManager = new TeacherManager();
            courseManager = new CourseManager();
        }
        //
        // GET: /Teacher/

        // SAVE TEACHER
        // action method for SaveTeacher(GET)
        [HttpGet]
        public ActionResult SaveTeacher()
        {
            // load department and designation in dropdown when page loaded
            ViewBag.DepartmentId = departmentManager.GetAllDepartmentsForDropDown();
            ViewBag.DesignationId = designationManager.GetAllDesignationsForDropDown();

            return View();
        }

        // action method for SaveTeacher(POST)
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            // check model state is valid or not
            if (!ModelState.IsValid)
            {
                ViewBag.Response = "Empty";
            }
            else
            {
                // if teacher contactNo is empty
                if (teacher.ContactNo == null)
                {
                    teacher.ContactNo = "No ContactNo";
                }

                // save teacher
                ViewBag.Response = teacherManager.Save(teacher);
            }

            //load department and designation for dropdown
            ViewBag.DepartmentId = departmentManager.GetAllDepartmentsForDropDown();
            ViewBag.DesignationId = designationManager.GetAllDesignationsForDropDown();
            ModelState.Clear();

            return View();
        }

        // ASSIGN COURSE TO TEACHER

        // action method for AssignCourseToTeacher[GET]
        [HttpGet]
        public ActionResult AssignCourseToTeacher()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            return View();
        }

        // action method for AssignCourseToTeacher[POST]
        [HttpPost]
        public ActionResult AssignCourseToTeacher(AssignCourseToTeacher assignCourse)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Response = teacherManager.CourseAssign(assignCourse);
            }
            else
            {
                ViewBag.Response = "Empty";
            }

            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            ModelState.Clear();
            return View();
        }

        // get all teacher by department selection
        public JsonResult GetAllTeacherByDepartment(int deptId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachersByDepartment(deptId);
            return Json(teachers);
        }

        // get all course by department selection
        public JsonResult GetAllCourseByDepartment(int deptId)
        {
            List<Course> courses = courseManager.GetAllCoursesByDepartmentId(deptId);
            return Json(courses);
        }

        // get teacher info by teacher id
        public JsonResult GetTeacherInfoByTeacherId(int id)
        {
            Teacher teacher = teacherManager.GetTeacherByTeacherId(id);
            TeacherViewModel teacherViewModel = new TeacherViewModel();

            decimal CreditToBeTaken = teacher.CreditTaken;
            decimal totalCreditOfTeacher = teacherManager.GetTotalCourseCreditTakenByTeacher(id);

            decimal remainingCredit = CreditToBeTaken - totalCreditOfTeacher;

            teacherViewModel.Id = teacher.Id;
            teacherViewModel.Name = teacher.Name;
            teacherViewModel.CreditTaken = teacher.CreditTaken;
            teacherViewModel.RemainingCredit = remainingCredit;

            return Json(teacherViewModel);
        }

        // get course info by course id
        public JsonResult GetCourseInfoByCourseId(int courseId)
        {
            Course course = courseManager.GetCourseByCourseId(courseId);
            return Json(course);
        }

	}
}