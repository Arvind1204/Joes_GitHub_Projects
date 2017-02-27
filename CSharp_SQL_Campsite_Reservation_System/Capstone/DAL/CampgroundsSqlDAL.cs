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
    public class CampgroundsSqlDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CapstoneDatabase"].ConnectionString;

        public CampgroundsSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Campground> GetCampgrounds(int park_id)
        {
            List<Campground> CampgroundOutput = new List<Campground>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * FROM Campground WHERE park_id=@park_id";
                    cmd.Parameters.AddWithValue("@park_id",park_id);
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Campground currentCampground = new Campground();
                        currentCampground.Campground_id = int.Parse(Convert.ToString(reader["campground_id"]));
                        currentCampground.Park_id = int.Parse(Convert.ToString(reader["park_id"]));
                        currentCampground.Name = Convert.ToString(reader["name"]);
                        currentCampground.Open_from_mm = int.Parse(Convert.ToString(reader["open_from_mm"]));
                        currentCampground.Open_to_mm = int.Parse(Convert.ToString(reader["open_to_mm"]));
                        currentCampground.Daily_fee = double.Parse(Convert.ToString(reader["daily_fee"]));                    
                        CampgroundOutput.Add(currentCampground);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return CampgroundOutput;
        }
    }
}
