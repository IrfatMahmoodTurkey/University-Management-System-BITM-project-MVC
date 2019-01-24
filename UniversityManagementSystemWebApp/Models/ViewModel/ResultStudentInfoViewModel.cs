using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModel
{
    public class ResultStudentInfoViewModel
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}