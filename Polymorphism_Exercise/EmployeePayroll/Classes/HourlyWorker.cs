using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Classes
{
    class HourlyWorker : IWorker
    {
        private string firstName;
        private string lastName;
        private double annualSalary;
        private double hourlyRate;

        public double HourlyRate
        {
            get { return hourlyRate; }
        }
        public double AnnualSalary
        {
            get { return annualSalary; }
        }
        public string FirstName
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return lastName; }
        }

        public HourlyWorker(double hourlyRate, string firstName, string lastName)
        {
            this.hourlyRate = hourlyRate;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public double CalculatedWeeklyPay(int hoursWorked)
        {
            double pay = hourlyRate * hoursWorked;
            if (hoursWorked > 40)
            {
                int overtime = hoursWorked - 40;
                pay = pay + (hourlyRate * overtime * .5);
            }
            return pay;
        }
    }
}
