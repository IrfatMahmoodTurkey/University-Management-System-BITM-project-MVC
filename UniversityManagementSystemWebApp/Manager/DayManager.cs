using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DayManager
    {
        private DayGateway dayGateway;

        public DayManager()
        {
            dayGateway = new DayGateway();
        }

        public List<SelectListItem> GetAllDaysForDropDown()
        {
            List<Day> days = dayGateway.GetAllDays();

            List<SelectListItem> selectListItems =
                days.ConvertAll(x => new SelectListItem() {Text = x.DayName, Value = x.Id.ToString()});

            List<SelectListItem> mainSelectListItems = new List<SelectListItem>();
            mainSelectListItems.Add(new SelectListItem(){Text = "--Select Day--", Value = ""});

            mainSelectListItems.AddRange(selectListItems);

            return mainSelectListItems;
        } 
    }
}