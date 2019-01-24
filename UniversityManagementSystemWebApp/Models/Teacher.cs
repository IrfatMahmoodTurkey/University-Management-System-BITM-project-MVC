using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Enter teacher name*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Enter teacher address*")]
        public string Address { get; set; }

        [Required(ErrorMessage = "*Enter teacher email*")]
        [EmailAddress(ErrorMessage = "*Enter email address is on correct format and valid*")]
        public string Email { get; set; }
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "*Select at least one designation*")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "*Select at least one department*")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "*Enter credit to be taken*")]
        [Range(0.1, Double.MaxValue, ErrorMessage = "*Credit can not be 0 or negative*")]
        public decimal CreditTaken { get; set; }
    }
}