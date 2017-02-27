using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Capstone.Models
{
    public class Campground
    {
        public int Campground_id { get; set; }

        public int Park_id { get; set; }

        public string Name { get; set; }

        public int Open_from_mm { get; set; }

        public int Open_to_mm { get; set; }

        public double Daily_fee { get; set; }

        public Campground(int park_Id)
        {
        }

        public Campground()
        {
        }

       public void DisplayCampground()
        {
            string openFromMonth = new DateTime(2017, Open_from_mm, 1).ToString("MMMM", CultureInfo.InvariantCulture);
            string openToMonth = new DateTime(2017, Open_to_mm, 1).ToString("MMMM", CultureInfo.InvariantCulture); ;
            Console.Write(("#" + Campground_id).PadRight(5));
            Console.Write(Name.PadRight(34));
            Console.Write(openFromMonth.PadRight(15));
            Console.Write(openToMonth.PadRight(15));
            Console.WriteLine("$" + Daily_fee + ".00");
        }

    }
}
