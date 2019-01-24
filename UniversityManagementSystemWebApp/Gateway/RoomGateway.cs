using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class RoomGateway:CommonGateway
    {
        public List<Room> GetAllRooms()
        {
            Connection.Open();

            string query = "SELECT * FROM Room";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();

            while (Reader.Read())
            {
                Room room = new Room();

                room.Id = Convert.ToInt32(Reader["Id"]);
                room.RoomNo = Reader["RoomNo"].ToString();

                rooms.Add(room);
            }

            Reader.Close();
            Connection.Close();

            return rooms;
        } 
    }
}