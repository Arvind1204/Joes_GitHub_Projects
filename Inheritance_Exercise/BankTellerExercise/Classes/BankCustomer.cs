using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class BankCustomer
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        private string name;
        private string address;
        private string phoneNumber;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public List<BankAccount> Accounts
        {
            get { return accounts; }
        }
        public bool IsVIP
        {
            get
            {
                DollarAmount totalBalance = new DollarAmount(0);
                foreach (BankAccount account in accounts)
                {
                    totalBalance = totalBalance.Plus(account.Balance);
                }
                if (totalBalance.ToDecimal() >= 25000.0M)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AddAccount(BankAccount newAccount)
        {
            accounts.Add(newAccount);
        }
    }
}
