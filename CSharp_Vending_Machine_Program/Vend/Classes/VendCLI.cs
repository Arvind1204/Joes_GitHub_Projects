using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vend.Classes;
using System.IO;

namespace Vend.Classes
{
    public class VendCLI
    {
        private List<VendingMachineItem> selectedProducts = new List<VendingMachineItem>();
        private VendingMachine vm = new VendingMachine();
        private FileWriter fw = new FileWriter();
        public VendCLI()
        {
            InitialMenu();
        }

        public void InitialMenu()
        {
            while (true)
            {
                Console.WriteLine("\n(1) Display Vending Machine Items\n(2) Purchase");
                string initialUserInput = Console.ReadLine().Trim();
                while (initialUserInput != "1" && initialUserInput != "2" && initialUserInput != "0")
                {
                    Console.WriteLine("\nInvalid Entry. Enter:\n(1) Display Vending Machine Items\n(2) Make Purchase");
                    initialUserInput = Console.ReadLine().Trim();
                }

                int userInput = int.Parse(initialUserInput);

                if (userInput == 1)
                {

                    Console.Write(("Location").PadRight(15));
                    Console.Write(("Name").PadRight(25));
                    Console.Write(("Price").PadRight(15));
                    Console.Write("Quantity in Stock\n");

                    foreach (KeyValuePair<string, VendingMachineItem> item in vm.MachineStock)
                    {
                            item.Value.DisplayItem();
                    }
                }
                if (userInput == 2)
                {
                    PurchaseMenu();
                }
                if (userInput == 0)
                {
                    PrintSalesReport();
                    Console.WriteLine("\nSales report printed.");
                }
            }

        }

        public void PurchaseMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("(1)Feed Money \n(2)SelectProduct \n(3)FinishTransaction \n\nCurrent Money Provided: $" + vm.CurrentBalance);
                string initialUserInput = Console.ReadLine().Trim();
                while (initialUserInput != "1" && initialUserInput != "2" && initialUserInput != "3")
                {
                    Console.WriteLine("\nInvalid Entry. Enter:\n\n(1)Feed Money \n(2)SelectProduct \n(3)FinishTransaction \nCurrent Money Provided: $" + vm.CurrentBalance);
                    initialUserInput = Console.ReadLine();
                }

                int userInput = int.Parse(initialUserInput);

                if (userInput == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the dollar amount ($1, $2, $5, $10)");
                    int fedMoney;
                    while (!int.TryParse(Console.ReadLine(), out fedMoney))
                    {
                        Console.WriteLine("\nInvalid entry. Please enter a full dollar amount ($1, $2, $5, $10)");
                    }

                    vm.FeedMoney(fedMoney);
                    try
                    {
                        fw.WriteToLog(fedMoney);
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\nError #1: Transactions not being recorded.\n\nPlease contact system administrator.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }


                }
                if (userInput == 2)
                {
                    SelectProduct();
                }
                if (userInput == 3)
                {
                    string endMessage = FinishTransaction();
                    Console.WriteLine(endMessage);
                    InitialMenu();
                }
            }
        }

        public void SelectProduct()
        {
            Console.WriteLine("\nPlease enter the slot number: ");
            string slotNumInput = Console.ReadLine().ToUpper().Trim();

            List<string> validSlots = new List<string>();
            foreach(KeyValuePair<string, VendingMachineItem> slot in vm.MachineStock)
            {
                validSlots.Add(slot.Key);
            }
            while(!validSlots.Contains(slotNumInput))
            {
                Console.WriteLine("\nInvalid slot number entered. Please enter valid slot number: ");
                slotNumInput = Console.ReadLine().ToUpper();
            }

            if (vm.MachineStock[slotNumInput].Stock == 0)
            {
                Console.WriteLine("\nSorry, that item is sold out.");
                return;
            }

            else if (!vm.MachineStock.ContainsKey(slotNumInput))
            {
                Console.WriteLine("\nSorry, that slot number does not exist.");
                return;
            }
            else if (vm.CurrentBalance < vm.MachineStock[slotNumInput].Price)
            {
                Console.WriteLine($"\nInsuficient funds to purchase {vm.MachineStock[slotNumInput].ItemName}. Please feed money or finish transaction.");
                return;
            }
            else
            {
                VendingMachineItem requestedItem = vm.MachineStock[slotNumInput];
                vm.MachineStock[slotNumInput].Stock -= 1;

                selectedProducts.Add(requestedItem);

                vm.CurrentBalance = vm.CurrentBalance - requestedItem.Price;

                Console.WriteLine("\nDispensing your " + requestedItem.ItemName + "\n");
                try
                {
                    fw.WriteToLog(requestedItem);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("\nError #1: Transactions not being recorded.\n\nPlease contact system administrator.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                return;
            }
        }

        public string FinishTransaction()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int balanceInPennies = (int)(vm.CurrentBalance * 100.0M);
            while (balanceInPennies != 0)
            {
                if (balanceInPennies / 25 > 0)
                {
                    quarters = balanceInPennies / 25;
                    balanceInPennies = balanceInPennies % 25;
                }
                if (balanceInPennies / 10 > 0)
                {
                    dimes = balanceInPennies / 10;
                    balanceInPennies = balanceInPennies % 10;
                }
                if (balanceInPennies /5 > 0)
                {
                    nickels = balanceInPennies / 5;
                    balanceInPennies = balanceInPennies % 5;
                }
            }

            vm.CurrentBalance = 0;

            try
            {
                fw.WriteToLog($"{quarters} quarters, {dimes} dimes, and {nickels} nickels");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine();
                Console.WriteLine("\nError #1: Transactions not being recorded.\n\nPlease contact system administrator.");
                Console.ReadKey();
                Environment.Exit(0);
            }


            return $"\nYour change is {quarters} quarters, {dimes} dimes, and {nickels} nickels.";

        }

        public void PrintSalesReport()
        {
            try
            {
            List<string> itemNamesSelected = new List<string>();
            foreach (VendingMachineItem item in selectedProducts)
            {
                itemNamesSelected.Add(item.ItemName);
            }
            
                fw.WriteToSalesReport(itemNamesSelected);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine();
                Console.WriteLine("\nError #1: Transactions not being recorded.\n\nPlease contact system administrator.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
