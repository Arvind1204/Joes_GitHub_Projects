using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Classes
{
    class VolunteerWorker : IWorker
    {
        private string firstName;
        private string lastName;


        public string FirstName
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return lastName; }
        }

        public VolunteerWorker(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public double CalculatedWeeklyPay(int hoursWorked)
        {
            return 0;
        }
    }
}
