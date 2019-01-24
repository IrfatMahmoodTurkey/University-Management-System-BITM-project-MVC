using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DepartmentGateway:CommonGateway
    {
        // SAVE DEPARTMENT
        // save department in database
        public int SaveDepartment(Department department)
        {
            Connection.Open();

            string query = "INSERT INTO Department VALUES (@code, @name)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@code", department.Code);
            Command.Parameters.AddWithValue("@name", department.Name);

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowsAffected;
        }

        //check department name or code is exists or not
        public bool CodeNameIsExists(Department department)
        {
            Connection.Open();

            string query = "SELECT * FROM Department WHERE Code = @code OR Name = @name";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@code", department.Code);
            Command.Parameters.AddWithValue("@name", department.Name);

            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;

            Connection.Close();
            return isExists;
        }

        // VIEW ALL DEPARTMENT
        // get all department from database
        public List<Department> GetAllDepartments()
        {
            Connection.Open();

            string query = "SELECT * FROM Department";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();

            while (Reader.Read())
            {
                Department department = new Department();

                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();

                departments.Add(department);
            }

            Reader.Close();
            Connection.Close();

            return departments;
        }

        // get department by department id
        public Department GetDepartmentByDepartmentId(int departmentId)
        {
            Connection.Open();

            string query = "SELECT * FROM Department WHERE Id = @departmentId";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@departmentId", departmentId);
            Reader = Command.ExecuteReader();
            Reader.Read();

            Department department = null;

            if (Reader.HasRows)
            {
                department = new Department();

                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();

            }

            Reader.Close();
            Connection.Close();

            return department;
        }
    }
}