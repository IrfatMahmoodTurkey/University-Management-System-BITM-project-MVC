using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class SemesterGateway:CommonGateway
    {
        // retrive all semester from database
        public List<Semester> GetAllSemesters()
        {
            Connection.Open();

            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();

            while (Reader.Read())
            {
                Semester semester = new Semester();

                semester.Id = Convert.ToInt32(Reader["Id"]);
                semester.SemesterName = Reader["SemesterName"].ToString();

                semesters.Add(semester);
            }

            Reader.Close();
            Connection.Close();

            return semesters;
        } 
    }
}