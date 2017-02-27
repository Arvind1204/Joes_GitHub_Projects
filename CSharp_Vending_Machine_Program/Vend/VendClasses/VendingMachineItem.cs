using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend.VendClasses
{
    public class VendingMachineItem
    {
        private string slot;
        private string itemName;
        private decimal price;
        private int stock;

        public string Slot
        {
            get { return slot;}
            set { slot = value; }
        }
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public void DisplayItem()
        {
            Console.Write(slot.PadRight(5));
            Console.Write(itemName.PadRight(15));
            Console.Write("$" + Math.Round(price, 2).ToString().PadRight(5));
            Console.WriteLine(stock);
        }
    }
}
