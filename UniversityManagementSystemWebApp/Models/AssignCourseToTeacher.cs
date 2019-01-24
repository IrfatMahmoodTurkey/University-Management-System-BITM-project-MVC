using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AssignCourseToTeacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Select at least one teacher")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Select at least one course")]
        public int CourseId { get; set; }
        public string Type { get; set; }
    }
}