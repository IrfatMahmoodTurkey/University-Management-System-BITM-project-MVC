using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DayGateway:CommonGateway
    {
        public List<Day> GetAllDays()
        {
            Connection.Open();

            string query = "SELECT * FROM Day ORDER BY Id ASC";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            List<Day> days = new List<Day>();

            while (Reader.Read())
            {
                Day day = new Day();

                day.Id = Convert.ToInt32(Reader["Id"]);
                day.DayName = Reader["DayName"].ToString();

                days.Add(day);
            }

            Reader.Close();
            Connection.Close();

            return days;
        }
    }
}