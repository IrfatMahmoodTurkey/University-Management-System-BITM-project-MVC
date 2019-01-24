using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class UnAllocteClassRoomGateway:CommonGateway
    {
        // UNALLOCATE ALL CLASSROOMS
        public int UnAllocateAllClassRooms()
        {
            Connection.Open();

            string query = "UPDATE AllocateClassRoom SET Type = 'UNALLOCATED'";
            Command = new SqlCommand(query, Connection);

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowsAffected;
        }
    }
}