using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnAssignCourseController : Controller
    {
        private UnAssignCourseManager unAssignCourseManager;

        public UnAssignCourseController()
        {
            unAssignCourseManager = new UnAssignCourseManager();
        }
        //
        // GET: /UnAssignCourse/
        [HttpGet]
        public ActionResult UnAssignCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnAssignCourse(string none)
        {
            ViewBag.Response = unAssignCourseManager.UnAssignAllCourse();
            return View();
        }
	}
}