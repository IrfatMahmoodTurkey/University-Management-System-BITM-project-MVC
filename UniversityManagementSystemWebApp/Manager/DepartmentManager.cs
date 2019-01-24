using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;

        public DepartmentManager()
        {
            departmentGateway = new DepartmentGateway();
        }

        // SAVE DEPARTMENT
        // save department
        public string SaveDepartment(Department department)
        {
            // check name or code already exists or not
            if (departmentGateway.CodeNameIsExists(department))
            {
                return "Exists";
            }
            else
            {
                // save department
                int rowsAffected = departmentGateway.SaveDepartment(department);

                if (rowsAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
        }

        // VIEW ALL DEPARTMENTS
        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }

        // get all department by department id
        public Department GetDepartmentByDepartmentId(int departmentId)
        {
            return departmentGateway.GetDepartmentByDepartmentId(departmentId);
        }

        // GET ALL DEPARTMENT TO SHOW ON DROPDOWN LIST
        public List<SelectListItem> GetAllDepartmentsForDropDown()
        {
            List<Department> departments = departmentGateway.GetAllDepartments();
            List<SelectListItem> selectListItems = departments.ConvertAll(x => new SelectListItem(){Text = x.Name, Value = x.Id.ToString()});

            List<SelectListItem> mainSelectListItems = new List<SelectListItem>();
            mainSelectListItems.Add(new SelectListItem(){Text = "--Select Department--", Value = ""});

            mainSelectListItems.AddRange(selectListItems);

            return mainSelectListItems;

        } 
    }
}