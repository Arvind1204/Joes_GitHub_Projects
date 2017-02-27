using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Classes
{
    class SalaryWorker : IWorker
    {
        private string firstName;
        private string lastName;
        private double annualSalary;

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

        public SalaryWorker(double annualSalary, string firstName, string lastName)
        {
            this.annualSalary = annualSalary;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public double CalculatedWeeklyPay(int hoursWorked)
        {
            double pay = annualSalary / 52;
            string payString = String.Format("{0:0.00}", pay);
            pay = double.Parse(payString);
            return pay;
        }
    }
}
