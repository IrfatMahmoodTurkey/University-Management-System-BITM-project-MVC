using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* Enter course code *")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* Course Code at least 5 character long*")]
        public string Code { get; set; }

        [Required(ErrorMessage = "* Enter course name *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Enter course credit *")]
        [Range(0.50, 5.00, ErrorMessage = "* Credit range is from 0.5 to 5.0 *")]
        public decimal Credit { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "* Select at least one department *")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "* Select  at least one semester *")]
        public int SemesterId { get; set; }
    }
}