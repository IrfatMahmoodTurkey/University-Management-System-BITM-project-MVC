using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Result
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select at least one Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Select at least one Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Select at least one Grade")]
        public int GradeId { get; set; }
        public string Type { get; set; }
    }
}