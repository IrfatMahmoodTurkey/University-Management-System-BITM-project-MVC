using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AllocateClassRoom
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select correct Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Select correct Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Select at least one Room")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Select at least one Day")]
        public int DayId { get; set; }
        [Required(ErrorMessage = "Enter Start Time")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Enter End Time")]
        public string EndTime { get; set; }
        public string Type { get; set; }
    }
}