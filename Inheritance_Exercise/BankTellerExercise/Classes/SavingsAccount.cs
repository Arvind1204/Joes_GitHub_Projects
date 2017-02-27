using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
         
        public override DollarAmount Withdraw(DollarAmount withdrawAmount)
        {
            if (Balance.ToDecimal() < 150.00M)
            {
                DollarAmount processingFee = new DollarAmount(200);
                withdrawAmount = withdrawAmount.Plus(processingFee);
                if ((Balance.ToDecimal() - withdrawAmount.ToDecimal()) < 0)
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
