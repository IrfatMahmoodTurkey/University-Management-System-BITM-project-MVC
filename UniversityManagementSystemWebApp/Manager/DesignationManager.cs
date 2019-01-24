using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DesignationManager
    {
        private DesignationGateway designationGateway;

        public DesignationManager()
        {
            designationGateway = new DesignationGateway();
        }

        // retrive all designations
        public List<Designation> GetAllDesignations()
        {
            return designationGateway.GetAllDesignations();
        }

        // retrive all designations for drop down ( Html.DropDownFor() )
        public List<SelectListItem> GetAllDesignationsForDropDown()
        {
            List<Designation> designations = designationGateway.GetAllDesignations();

            List<SelectListItem> selectListItems =
                designations.ConvertAll(x => new SelectListItem() {Text = x.DesignationName, Value = x.Id.ToString()});

            List<SelectListItem> mainSelectListItems = new List<SelectListItem>();
            mainSelectListItems.Add(new SelectListItem(){Text = "--Select designation--", Value = ""});

            mainSelectListItems.AddRange(selectListItems);

            return mainSelectListItems;
        } 
    }
}