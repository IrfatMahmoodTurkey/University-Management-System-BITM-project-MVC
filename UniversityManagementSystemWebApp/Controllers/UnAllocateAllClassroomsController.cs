using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnAllocateAllClassroomsController : Controller
    {
        private UnAllocateAllClassroomsManager unAllocateAllClassroomsManager;

        public UnAllocateAllClassroomsController()
        {
            unAllocateAllClassroomsManager = new UnAllocateAllClassroomsManager();
        }
        //
        // GET: /UnAllocateAllClassrooms/
        [HttpGet]
        public ActionResult UnAllocateClassrooms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnAllocateClassrooms(string none)
        {
            ViewBag.Response = unAllocateAllClassroomsManager.UnAllocateAllClassrooms();
            return View();
        }
	}
}