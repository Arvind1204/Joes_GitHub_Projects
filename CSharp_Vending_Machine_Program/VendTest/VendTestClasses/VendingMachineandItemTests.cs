using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vend.VendClasses;
using System.Collections.Generic;

namespace VendTest.VendTestClasses
{
    [TestClass]
    public class VendingMachineandItemTests
    {
        [TestMethod]
        public void VendingMachineTest()
        {
            //Declaring our test vending machine and getting it's stock.
            VendingMachine testMachine = new VendingMachine();
            Dictionary <string, VendingMachineItem> testStock = testMachine.MachineStock;

            //Tests on Item Names
            Assert.AreEqual("Wonka Bar", testStock["B3"].ItemName);
            Assert.AreEqual("Crunchie", testStock["B4"].ItemName);
            Assert.AreEqual("Cola", testStock["C1"].ItemName);
            Assert.AreEqual("Dr. Salt", testStock["C2"].ItemName);
            Assert.AreEqual("Mountain Melter", testStock["C3"].ItemName);

            //Test on Initial Quantity in Stock
            Assert.AreEqual(5, testStock["B3"].Stock);

            //Test on Slot Location
            Assert.AreEqual("B3", testStock["B3"].Slot);

            //Confirming we are taking in the correct number of lines
            Assert.AreEqual(16,testStock.Count);
        }
    }
}
