using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vend.Classes
{
    public class VendingMachine
    {
        //Private Variables
        private Dictionary<string, VendingMachineItem> machineStock;
        private decimal currentBalance;
        //Public Properties
        public Dictionary<string, VendingMachineItem> MachineStock
        {
            get { return machineStock; }
            set { machineStock = value; }
        }
        public decimal CurrentBalance
        {
            get { return currentBalance; }
            set { currentBalance = value; }
        }
        //Constructor which calls the ReadStock method to populate the machineStock
        public VendingMachine()
        {
            machineStock = ReadStockFromFile();
        }
        //Methods
        public void FeedMoney(decimal amountFed)
        {
            currentBalance += amountFed;
        }
        private Dictionary<string, VendingMachineItem> ReadStockFromFile()
        {
            Dictionary<string, VendingMachineItem> output = new Dictionary<string, VendingMachineItem>();
            using (StreamReader sr = new StreamReader(@"C:\VendFiles\vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] splitLine = line.Split(new char[] { '|' });
                    VendingMachineItem itemBeingAdded = new VendingMachineItem();
                    itemBeingAdded.Slot = splitLine[0];
                    itemBeingAdded.ItemName = splitLine[1];
                    itemBeingAdded.Price = decimal.Parse(splitLine[2]);
                    itemBeingAdded.Stock = 5; //Establishes each item at an initial stock of 5
                    output.Add(itemBeingAdded.Slot, itemBeingAdded);
                }
            }
            return output;
        }
    }
}
