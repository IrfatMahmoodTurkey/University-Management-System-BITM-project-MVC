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
    public class CourseController : Controller
    {
        private DepartmentManager departmentManager;
        private SemesterManager semesterManager;
        private CourseManager courseManager;

        public CourseController()
        {
            departmentManager = new DepartmentManager();
            semesterManager = new SemesterManager();
            courseManager = new CourseManager();
        }
        //
        // GET: /Course/

        // SAVE COURSE
        // action method for SaveCourse(GET)
        [HttpGet]
        public ActionResult SaveCourse()
        {
            // load department and Semester in dropdown
            ViewBag.DepartmentId = departmentManager.GetAllDepartmentsForDropDown();
            ViewBag.SemesterId = semesterManager.GetAllSemestersForDropDown();

            return View();
        }

        // action method for SaveCourse(POST). The method is called when Save button clicked in UI
        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            // first check model state is valid or not
            if (!ModelState.IsValid)
            {
                ViewBag.Response = "Empty";
            }
            else
            {
                // if course description is empty
                if (course.Description == null)
                {
                    course.Description = "No description";
                }

                // save course
                ViewBag.Response = courseManager.Save(course);
            }

            // load department and Semester in dropdown
            ViewBag.DepartmentId = departmentManager.GetAllDepartmentsForDropDown();
            ViewBag.SemesterId = semesterManager.GetAllSemestersForDropDown();
            ModelState.Clear();


            return View();

        }

        // VIEW COURSE STATICS

        // action method for ViewCourseStatics (GET)
        [HttpGet]
        public ActionResult ViewCourseStatics()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            return View();
        }

        // get course statics by department
        public JsonResult GetCourseWithTeacherByDepartment(int departmentId)
        {
            List<ViewCourseStaticsViewModel> courseStatics = courseManager.GetAllCourseWithTeacherAssigned(departmentId);

            return Json(courseStatics);
        }
	}
}