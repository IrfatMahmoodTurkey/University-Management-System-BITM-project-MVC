using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class GradeManager
    {
        private GradeGateway gradeGateway;

        public GradeManager()
        {
            gradeGateway = new GradeGateway();
        }

        public List<SelectListItem> GetAllGradesForDropDown()
        {
            List<Grade> grades = gradeGateway.GetAllGrades();

            List<SelectListItem> selectListItems = grades.ConvertAll(x => new SelectListItem() {Text = x.GradeLetter, Value = x.Id.ToString()});

            List<SelectListItem> mainSelectListItems = new List<SelectListItem>();
            mainSelectListItems.Add(new SelectListItem(){Text = "--Select Grade--", Value = ""});

            mainSelectListItems.AddRange(selectListItems);

            return mainSelectListItems;
        } 
    }
}