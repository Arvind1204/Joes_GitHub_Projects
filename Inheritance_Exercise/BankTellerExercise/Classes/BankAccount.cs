using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        // DollarAmount x = new DollarAmount(20);
        private DollarAmount balance;
        public DollarAmount Balance
        {
            get { return balance; }
        }

        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public BankAccount()
        {
            balance = new DollarAmount(0);
        }

        public DollarAmount Deposit (DollarAmount amountToDeposit)
        {
            balance = balance.Plus(amountToDeposit);
            return balance;
        }

        public virtual DollarAmount Withdraw (DollarAmount amountToWithdraw)
        {
            balance = balance.Minus(amountToWithdraw);
            return balance;
        }

        public void Transfer (BankAccount destinationAccount, DollarAmount transferAmount)
        {
            destinationAccount.Deposit(transferAmount);
            balance = Withdraw(transferAmount);
        }


    }
}
