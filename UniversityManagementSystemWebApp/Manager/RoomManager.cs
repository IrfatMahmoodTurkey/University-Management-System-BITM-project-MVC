using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class RoomManager
    {
        private RoomGateway roomGateway;

        public RoomManager()
        {
            roomGateway = new RoomGateway();
        }

        public List<SelectListItem> GetAllRoomsForDropDown()
        {
            List<Room> rooms = roomGateway.GetAllRooms();

            List<SelectListItem> selectListItems =
                rooms.ConvertAll(x => new SelectListItem() {Text = x.RoomNo, Value = x.Id.ToString()});
            List<SelectListItem> mainSelectListItems = new List<SelectListItem>();
            mainSelectListItems.Add(new SelectListItem(){Text = "--Select Room--", Value = ""});

            mainSelectListItems.AddRange(selectListItems);

            return mainSelectListItems;
        } 
    }
}