using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModel
{
    public class ViewClassScheduleViewModel
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomNo { get; set; }
        public string DayName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}