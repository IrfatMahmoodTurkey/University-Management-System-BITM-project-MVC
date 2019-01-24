using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class HomeController : Controller
    {
        private HomeManager homeManager;
        public HomeController()
        {
            homeManager = new HomeManager();   
        }
        public ActionResult Index()
        {
            ViewBag.Departments = homeManager.GetTotalDepartments();
            ViewBag.Teachers = homeManager.GetTotalTeachers();
            ViewBag.StudentsRegisterd = homeManager.GetRegisteredStudent();
            ViewBag.Classrooms = homeManager.GetTotalClassrooms();
            ViewBag.Date = DateTime.Now.ToString();

            ViewBag.StudentByYear = homeManager.GetStudentByYear();
            ViewBag.TeachersInfo = homeManager.GetAllTeacherInfo();
            ViewBag.StudentInfo = homeManager.GetAllStudentInfo();

            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}