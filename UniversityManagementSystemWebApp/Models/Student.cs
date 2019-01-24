using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string RegNo { get; set; }

        [Required(ErrorMessage = "*Enter Student Name*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Enter Student Email address*")]
        [EmailAddress(ErrorMessage = "*Email address is not Valid*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Enter Student Contact No*")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "*Select Registration Date*")]
        public string Date { get; set; }

        [Required(ErrorMessage = "*Enter Student Address*")]
        public string Address { get; set; }

        [Required(ErrorMessage = "*Select at least one Department*")]
        public int DepartmentId { get; set; }
        public string Year { get; set; }
    }
}