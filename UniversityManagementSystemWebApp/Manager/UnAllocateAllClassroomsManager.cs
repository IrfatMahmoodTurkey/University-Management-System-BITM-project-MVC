using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;

namespace UniversityManagementSystemWebApp.Manager
{
    public class UnAllocateAllClassroomsManager
    {
        private UnAllocteClassRoomGateway unAllocteClassRoomGateway;

        public UnAllocateAllClassroomsManager()
        {
            unAllocteClassRoomGateway = new UnAllocteClassRoomGateway();
        }

        public string UnAllocateAllClassrooms()
        {
            int rowsAffected = unAllocteClassRoomGateway.UnAllocateAllClassRooms();

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
}