using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class GradeGateway:CommonGateway
    {
        public List<Grade> GetAllGrades()
        {
            Connection.Open();

            string query = "SELECT * FROM Grade ORDER BY Id ASC";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();

            List<Grade> grades = new List<Grade>();

            while (Reader.Read())
            {
                Grade grade = new Grade();

                grade.Id = Convert.ToInt32(Reader["Id"]);
                grade.GradeLetter = Reader["GradeLetter"].ToString();

                grades.Add(grade);
            }

            Reader.Close();
            Connection.Close();

            return grades;
        } 
    }
}