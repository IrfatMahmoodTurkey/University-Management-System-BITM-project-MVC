using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Manager
{
    public class HomeManager
    {
        private HomeGateway homeGateway;

        public HomeManager()
        {
            homeGateway = new HomeGateway();
        }

    
        public int GetTotalDepartments()
        {
            return homeGateway.GetTotalDepartment();
        }

        public int GetTotalTeachers()
        {
            return homeGateway.GetTotalTeacher();
        }

        public int GetRegisteredStudent()
        {
            return homeGateway.GetTotalRegisteredStudent();
        }

        public int GetTotalClassrooms()
        {
            return homeGateway.GetTotalClassrooms();
        }

        public List<StudentByYearViewModel> GetStudentByYear()
        {
            return homeGateway.GetNoOfStudentByYear();
        }

        public List<TeacherInfoHomeViewModel> GetAllTeacherInfo()
        {
            return homeGateway.GetTeacherInfo();
        }

        public List<StudentInfoHomeViewModel> GetAllStudentInfo()
        {
            return homeGateway.GetAllStudentInfo();
        } 
    }
}