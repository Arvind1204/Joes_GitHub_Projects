using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Park
    {
        public int Park_id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Establish_date { get; set; }

        public int Area { get; set; }

        public int Visitors { get; set; }

        public string Description { get; set; }

        public void DisplayPark()
        {
            Console.WriteLine(Name + " National Park");
            Console.Write("Location: ".PadRight(20));
            Console.WriteLine(Location);
            Console.Write("Established: ".PadRight(20));
            Console.WriteLine(Establish_date.ToShortDateString());
            Console.Write("Area: ".PadRight(20));
            Console.WriteLine(Area.ToString("#,###") + " sq km");
            Console.Write("Annual Visitors: ".PadRight(20));
            Console.WriteLine(Visitors.ToString("#,###"));
            Console.WriteLine();
            Console.WriteLine(Description.PadLeft(5));
            Console.WriteLine();
        }
    }
}
