using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class SemesterManager
    {
        private SemesterGateway semesterGateway;

        public SemesterManager()
        {
            semesterGateway = new SemesterGateway();
        }

        // retrive all semesters
        public List<Semester> GetAllSemesters()
        {
            return semesterGateway.GetAllSemesters();
        }

        // retrive all semesters for dropdown ( Html.DropDownFor() )
        public List<SelectListItem> GetAllSemestersForDropDown()
        {
            List<Semester> semesters = semesterGateway.GetAllSemesters();

            List<SelectListItem> selectListItems =
                semesters.ConvertAll(x => new SelectListItem() {Text = x.SemesterName, Value = x.Id.ToString()});

            List<SelectListItem> mainSelectListItems = new List<SelectListItem>();
            mainSelectListItems.Add(new SelectListItem() { Text = "--Select Semester--", Value = "" });

            mainSelectListItems.AddRange(selectListItems);

            return mainSelectListItems;
        } 
    }
}