using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager = new DepartmentManager();
        }
        //
        // GET: /Department/

        //SAVE DEPARTMENT
        // action method for SaveDepartment(GET)
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        // action method for SaveDepartment(POST)
        [HttpPost]
        public ActionResult Save(Department department)
        {
            // check model state is valid or not
            if (ModelState.IsValid)
            {
                // save department
                ViewBag.Response = departmentManager.SaveDepartment(department);

                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.Response = "Empty";

                ModelState.Clear();
                return View();
            }
        }

        // VIEW ALL DEPARTMENT
        // action method for ViewAllDepartments(GET)
        [HttpGet]
        public ActionResult ViewAllDepartments()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }

    }
}