using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.DAL;

namespace Capstone.Tests
{
    [TestClass]
    public class SiteSqlDAL_Test
    {

        private TransactionScope tran;
        private string connectionString = @"Data Source=DESKTOP-R7C1GEC\SQLEXPRESS;Initial Catalog=NationalParkCampsiteReservationDB;Integrated Security=True";
        private int numberOfSites;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                connection.Open();

                cmd = new SqlCommand("SELECT COUNT(*) FROM site");
                cmd.Connection = connection;
                numberOfSites = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (8, 1, 10000, 1, 10000, 1)");
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void SiteSqlDALTest()
        {
        }

        [TestMethod]
        public void GetAvailableSites_Test()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void ReserveSite_Test()
        {

        }

        [TestMethod]
        public void GetReservationId_Test()
        {

        }
    }
}
