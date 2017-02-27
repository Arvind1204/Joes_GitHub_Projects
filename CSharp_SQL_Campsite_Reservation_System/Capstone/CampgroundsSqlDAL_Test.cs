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
    public class CampgroundsSqlDAL_Test
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=DESKTOP-R7C1GEC\SQLEXPRESS;Initial Catalog=NationalParkCampsiteReservationDB;Integrated Security=True";
        private int numberOfCampgrounds;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                connection.Open();

                cmd = new SqlCommand("SELECT COUNT(*) FROM campgrounds");
                cmd.Connection = connection;
                numberOfCampgrounds = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO campgrounds (park_id, name, open_from_mm, open_to_mm, daily_fee) VALUES ('3', 'Aolis', 1, 12, 1000.00)");
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void CampgroundsSqlDALTest()
        {
        }

        [TestMethod]
        public void GetAllCampgrounds_Test()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }
    }
}
