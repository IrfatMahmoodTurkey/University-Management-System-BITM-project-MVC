using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DesignationGateway:CommonGateway
    {
        // retrive all designation from database
        public List<Designation> GetAllDesignations()
        {
            Connection.Open();

            string query = "SELECT * FROM Designation";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();

            while (Reader.Read())
            {
                Designation designation = new Designation();

                designation.Id = Convert.ToInt32(Reader["Id"]);
                designation.DesignationName = Reader["DesignationName"].ToString();

                designations.Add(designation);
            }

            Reader.Close();
            Connection.Close();

            return designations;
        } 
    }
}