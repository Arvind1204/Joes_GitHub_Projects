using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayroll.Classes;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IWorker> companyPayroll = new List<IWorker>();

            companyPayroll.Add(new SalaryWorker(39000.0, "Mickey", "Mouse"));
            companyPayroll.Add(new HourlyWorker(15.0, "Daffey", "Duck"));
            companyPayroll.Add(new VolunteerWorker("Limp", "Bizkit"));
            companyPayroll.Add(new SalaryWorker(4000000.0, "Minnie", "Mouse"));


            List<int> hoursWorked = new List<int>();
            List<double> weeklyPay = new List<double>();

            int totalHours = 0;
            double totalPay = 0;

            Random rand = new Random();

            foreach (IWorker worker in companyPayroll)
            {
                
                int randomHoursWorked = rand.Next(0,100);
                weeklyPay.Add(worker.CalculatedWeeklyPay(randomHoursWorked));
                hoursWorked.Add(randomHoursWorked);

                totalHours += randomHoursWorked;
                totalPay += worker.CalculatedWeeklyPay(randomHoursWorked);
            }

            Console.Write(("Employee").PadRight(20));
            Console.Write(("Hours Worked").PadRight(20));
            Console.Write("Pay");
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                Console.Write((companyPayroll[i].LastName + ", " + companyPayroll[i].FirstName).PadRight(20));
                Console.Write(hoursWorked[i].ToString().PadRight(20));
                Console.Write(weeklyPay[i].ToString());
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Total Hours: " + totalHours.ToString());
            Console.WriteLine("Total Pay: $" + totalPay.ToString());
            Console.WriteLine();


        }
    }
}
