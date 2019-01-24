using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* Enter Department Code *")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = ("* Code must be 2 to 7 character long *"))]
        public string Code { get; set; }

        [Required(ErrorMessage = "* Enter Department Name *")]
        public string Name { get; set; }
    }
}