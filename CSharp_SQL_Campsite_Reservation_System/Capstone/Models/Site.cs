using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Site
    {
        public int Site_Number { get; set; }

        public int Max_occupancy { get; set; }

        public bool Accessibile { get; set; }

        public int Max_rv_length { get; set; }

        public bool Utilities { get; set; }

        public double Daily_Fee { get; set; }

        public Site(int campground_id)
        {
        }

        public void DisplaySite(int numOfDays)
        {
            Console.Write(Site_Number.ToString().PadRight(12));
            Console.Write(Max_occupancy.ToString().PadRight(12));
            Console.Write((Accessibile ? "Yes" : "No").ToString().PadRight(15));
            if (Max_rv_length == 0)
            {
                Console.Write("N/A".PadRight(18));
            }
            else
            {
                Console.Write(Max_rv_length.ToString().PadRight(18));
            }
            Console.Write((Utilities ? "Yes" : "No").ToString().PadRight(12));
            Console.WriteLine("$" + (Daily_Fee * numOfDays).ToString() + ".00".PadRight(12));
        }
    }
}
