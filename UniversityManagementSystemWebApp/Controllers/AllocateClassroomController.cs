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
    public class AllocateClassroomController : Controller
    {
        private DepartmentManager departmentManager;
        private CourseManager courseManager;
        private RoomManager roomManager;
        private DayManager dayManager;
        private AllocateClassManager allocateClassManager;

        public AllocateClassroomController()
        {
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            roomManager = new RoomManager();
            dayManager = new DayManager();
            allocateClassManager = new AllocateClassManager();
        }
        //
        // GET: /AllocateClassRoom/

        // ALLOCATE CLASSROOMS
        // action result method for AllocateClassrooms[GET]
        [HttpGet]
        public ActionResult AllocateClassrooms()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            ViewBag.Rooms = roomManager.GetAllRoomsForDropDown();
            ViewBag.Days = dayManager.GetAllDaysForDropDown();

            return View();
        }

        // get course by department dropdown
        public JsonResult GetCourseByDepartment(int departmentId)
        {
            List<Course> courses = courseManager.GetAllCoursesByDepartmentId(departmentId);
            return Json(courses);
        }

        [HttpPost]
        public ActionResult AllocateClassrooms(AllocateClassRoom allocateClassRoom)
        {
            if (ModelState.IsValid)
            {
                if (CheckTimeIsValidOrNot(allocateClassRoom))
                {
                    ViewBag.Response = allocateClassManager.AllocateClassrooms(allocateClassRoom);
                }
                else
                {
                    ViewBag.Response = "Invalid";
                }
            }
            else
            {
                ViewBag.Response = "Empty";
            }

            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            ViewBag.Rooms = roomManager.GetAllRoomsForDropDown();
            ViewBag.Days = dayManager.GetAllDaysForDropDown();
            ModelState.Clear();

            return View();
        }

        public bool CheckTimeIsValidOrNot(AllocateClassRoom allocateClassRoom)
        {
            //int fromHour = allocateClassRoom.FromHour;
            //int toHour = allocateClassRoom.ToHour;
            //int fromMin = allocateClassRoom.FromMin;
            //int toMin = allocateClassRoom.ToMin;
            //string fromFormat = allocateClassRoom.FromFormat;
            //string toFormat = allocateClassRoom.ToFormat;

            TimeSpan time1 = DateTime.Parse(allocateClassRoom.StartTime).TimeOfDay;
            TimeSpan time2 = DateTime.Parse(allocateClassRoom.EndTime).TimeOfDay;
            TimeSpan diff = DateTime.Parse("1:00:00").TimeOfDay;

            if (time1 < time2)
            {
                if (time2 - time1 < diff)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        // VIEW CLASS ALLOCATION
        // action method for ViewClassAllocation(GET)
        [HttpGet]
        public ActionResult ViewClassAllocation()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropDown();
            return View();
        }

        public JsonResult GetScheduleByDepartmentId(int departmentId)
        {
            List<ViewClassScheduleAndAllocationViewModel> models =
                allocateClassManager.GetClassScheduleByDepartment(departmentId);
            return Json(models);
        }
	}
}