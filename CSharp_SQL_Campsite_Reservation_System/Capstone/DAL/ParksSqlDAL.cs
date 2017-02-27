using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;
using System.Configuration;

namespace Capstone.DAL
{
    public class ParksSqlDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CapstoneDatabase"].ConnectionString;

        public ParksSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Park> GetParks()
        {
            List<Park> parkOutput = new List<Park>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * FROM park";
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park currentPark = new Park();
                        currentPark.Park_id = int.Parse(Convert.ToString(reader["park_id"]));
                        currentPark.Name = Convert.ToString(reader["name"]);
                        currentPark.Location = Convert.ToString(reader["location"]);
                        currentPark.Establish_date = Convert.ToDateTime(reader["establish_date"]);
                        currentPark.Area = int.Parse(Convert.ToString(reader["area"]));
                        currentPark.Visitors = int.Parse(Convert.ToString(reader["visitors"]));
                        parkOutput.Add(currentPark);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return parkOutput;
        }

        public Park GetPark(int park_id)
        {
            Park currentPark = new Park();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * FROM park WHERE park_id=@park_id";
                    cmd.Parameters.AddWithValue("@park_id", park_id);
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        currentPark.Park_id = int.Parse(Convert.ToString(reader["park_id"]));
                        currentPark.Name = Convert.ToString(reader["name"]);
                        currentPark.Location = Convert.ToString(reader["location"]);
                        currentPark.Establish_date = Convert.ToDateTime(reader["establish_date"]);
                        currentPark.Area = int.Parse(Convert.ToString(reader["area"]));
                        currentPark.Visitors = int.Parse(Convert.ToString(reader["visitors"]));
                        currentPark.Description = Convert.ToString(reader["description"]);
                    }
                    return currentPark;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
