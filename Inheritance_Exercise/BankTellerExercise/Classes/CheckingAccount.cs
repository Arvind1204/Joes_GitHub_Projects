using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTellerExercise.Classes;

namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public override DollarAmount Withdraw(DollarAmount withdrawAmount)
        {
           if (withdrawAmount.ToDecimal() > Balance.ToDecimal())
            {
                DollarAmount overdraftFee = new DollarAmount(1000);
                withdrawAmount = withdrawAmount.Plus(overdraftFee);
                if ((Balance.ToDecimal() - withdrawAmount.ToDecimal()) < -100)
                {
                    return Balance;
                }
                else
                {
                    DollarAmount newBalance = base.Withdraw(withdrawAmount);
                    return newBalance;
                }
            }
            else
            {
                DollarAmount newBalance = base.Withdraw(withdrawAmount);
                return newBalance;
            }
        } 
    }
}
