using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModel
{
    public class ViewCourseStaticsViewModel
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public string AssignTo { get; set; }
    }
}