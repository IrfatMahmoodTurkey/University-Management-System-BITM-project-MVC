using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class EnrollStudent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select at least one Student Reg No")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Select at least one Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Enter date")]
        public string Date { get; set; }
        public string Type { get; set; }
    }
}