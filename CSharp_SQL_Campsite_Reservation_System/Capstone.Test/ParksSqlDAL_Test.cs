using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.DAL;

namespace Capstone.Tests
{
    [TestClass]
    public class ParksSqlDAL_Test
    {

        private TransactionScope tran;
        private string connectionString = @"Data Source=DESKTOP-R7C1GEC\SQLEXPRESS;Initial Catalog=NationalParkCampsiteReservationDB;Integrated Security=True";
        private int numberOfParks;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                connection.Open();

                cmd = new SqlCommand("SELECT COUNT(*) FROM park");
                cmd.Connection = connection;
                numberOfParks = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO park (name, location, establish_date, area, visitors, description) VALUES ('Nilpham', 'Underworld', 0001/01/01, 99999, 999999, 'Welcome to the Home of Hades')");
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void ParksSqlDALTest()
        {
        }

        [TestMethod]
        public void GetAllParks_Test()
        {
            ParksSqlDAL parksSqlDAL = new ParksSqlDAL(connectionString);

            List<Park> allParks = new List<Park>();

            allParks = employeeSqlDal.GetAllEmployees();

            Assert.IsNotNull(allParks);
            Assert.AreEqual(numberOfParks + 1, allParks.Count);
        }

        [TestMethod]
        public void GetPark_TEST()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }
    }
}
