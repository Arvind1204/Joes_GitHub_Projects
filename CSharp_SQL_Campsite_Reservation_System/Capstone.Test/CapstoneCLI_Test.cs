using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;


namespace Capstone.Tests
{
    [TestClass]
    public class CapstoneCLI_Test
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=DESKTOP-R7C1GEC\SQLEXPRESS;Initial Catalog=NationalParkCampsiteReservationDB;Integrated Security=True";
        


        [TestMethod]
        public void CapstoneCLITest()
        {
        }

        [TestMethod]
        public void InitialMenu_Test()
        {

        }

        [TestMethod]
        public void ParkMenu_Test()
        {

        }

        [TestMethod]
        public void ViewCampgrounds_Test()
        {

        }

        [TestMethod]
        public void SearchMenu_Test()
        {

        }

        [TestMethod]
        public void ReserveCampsite_Test()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }
    }
}
