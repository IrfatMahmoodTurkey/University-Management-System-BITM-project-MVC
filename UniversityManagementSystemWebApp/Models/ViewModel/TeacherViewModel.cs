using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModel
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CreditTaken { get; set; }
        public decimal RemainingCredit { get; set; }
    }
}