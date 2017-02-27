using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vend.Classes
{
    public class FileWriter
    {
        public FileWriter()
        {

        }
        public void WriteToLog(decimal dollarAmount)
        {
            string path = @"C:\VendFiles\Vend\";
            string file = "TransactionLog.txt";
            string fullPath = Path.Combine(path, file);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.Now + " Customer added $" + dollarAmount);
            }
        }

        public void WriteToLog(VendingMachineItem item)
        {
            string path = @"C:\VendFiles\Vend\";
            string file = "TransactionLog.txt";
            string fullPath = Path.Combine(path, file);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.Now + " Customer purchased a " + item.ItemName);
            }
        }

        public void WriteToLog(string change)
        {
            string path = @"C:\VendFiles\Vend\";
            string file = "TransactionLog.txt";
            string fullPath = Path.Combine(path, file);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.Now + " Customer finished their transaction, receiving " + change + " in change");
            }

        }

        public void WriteToSalesReport(List<string> selectedProducts)
        {
            VendingMachine vm = new VendingMachine();
            List<string> newItemsSold = selectedProducts;

            string fullpath = @"C:\VendFiles\Vend\" + " ​Vendo-­Matic-­Sales­-" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".txt";

            using (StreamWriter sw = new StreamWriter(fullpath, false))
            {
                decimal runningTotal = 0M;
                foreach (KeyValuePair<string, VendingMachineItem> item in vm.MachineStock)
                {
                    decimal itemsAdded = 0M;
                    if (selectedProducts.Contains(item.Value.ItemName))
                    {
                        foreach (string name in newItemsSold)
                        {
                            if (name.Equals(item.Value.ItemName))
                            {
                                itemsAdded++;
                            }
                        }
                        sw.WriteLine(item.Value.ItemName + " | " + itemsAdded);
                        runningTotal += Math.Round((item.Value.Price * itemsAdded), 2);
                    }
                    else
                    {
                        sw.WriteLine(item.Value.ItemName + " | " + 0);
                    }
                }
                sw.WriteLine();
                sw.WriteLine(DateTime.Now + " **TOTAL SALES** $" + runningTotal);
            }
        }
    }
}
