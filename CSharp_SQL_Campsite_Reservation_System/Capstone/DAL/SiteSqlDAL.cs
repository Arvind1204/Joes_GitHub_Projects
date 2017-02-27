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
    public class SiteSqlDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CapstoneDatabase"].ConnectionString;

        public SiteSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Site> GetAvailableSites(int campground_id, DateTime arrival_date, DateTime departure_date)
        {
            List<Site> SiteOutput = new List<Site>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT TOP 5 s.site_number,s.max_occupancy,s.accessible,s.max_rv_length,s.utilities,cg.daily_fee FROM site s join campground cg ON cg.campground_id = s.campground_id WHERE cg.campground_id = @campground_id AND s.site_id NOT IN (SELECT r.site_id FROM site s join reservation r ON s.site_id = r.site_id WHERE ((@arrival_date > r.from_date AND @arrival_date < r.to_date)OR(@departure_date > r.from_date AND @departure_date < r.to_date)OR(@arrival_date < r.from_date AND @departure_date > r.to_date)OR(@arrival_date = r.from_date AND @departure_date = r.to_date)))";
                    cmd.Parameters.AddWithValue("@campground_id", campground_id);
                    cmd.Parameters.AddWithValue("@arrival_date", arrival_date);
                    cmd.Parameters.AddWithValue("@departure_date", departure_date);
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Site currentSite = new Site(campground_id);
                        currentSite.Site_Number = int.Parse(Convert.ToString(reader["site_number"]));
                        currentSite.Max_occupancy = int.Parse(Convert.ToString(reader["max_occupancy"]));
                        currentSite.Accessibile = Convert.ToBoolean(reader["accessible"]);
                        currentSite.Max_rv_length = int.Parse(Convert.ToString(reader["max_rv_length"]));
                        currentSite.Utilities = Convert.ToBoolean(reader["utilities"]);
                        currentSite.Daily_Fee = double.Parse(Convert.ToString(reader["daily_fee"]));
                        SiteOutput.Add(currentSite);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return SiteOutput;
        }

        public bool ReserveSite(Reservation reservation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO reservation (site_id,name,from_date,to_date) VALUES (@site_id,@name,@arrivalDate,@departureDate)", connection);
                    cmd.Parameters.AddWithValue("@site_id", reservation.Site_id);
                    cmd.Parameters.AddWithValue("@name", reservation.Name);
                    cmd.Parameters.AddWithValue("@arrivalDate", reservation.From_Date);
                    cmd.Parameters.AddWithValue("@departureDate", reservation.To_Date);
                    cmd.Connection = connection;
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public int GetReservationId(Reservation reservation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "SELECT r.reservation_id FROM reservation r WHERE r.name = @name AND r.from_date = @arrivalDate AND r.to_date = @departureDate";
                    cmd1.Parameters.AddWithValue("@name", reservation.Name);
                    cmd1.Parameters.AddWithValue("@arrivalDate", reservation.From_Date);
                    cmd1.Parameters.AddWithValue("@departureDate", reservation.To_Date);
                    cmd1.Connection = connection;
                    SqlDataReader reader = cmd1.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservation newReservation = new Reservation();
                        newReservation.Reservation_id = int.Parse(Convert.ToString(reader["reservation_id"]));
                        return newReservation.Reservation_id;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return 0;
        }
    }
}
