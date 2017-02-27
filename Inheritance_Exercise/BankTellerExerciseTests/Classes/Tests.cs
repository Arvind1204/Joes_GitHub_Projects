using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests.Classes
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ToString()
        {
            DollarAmount exercise = new DollarAmount(3210);
            Assert.AreEqual("$32.10", exercise.ToString());

            exercise = new DollarAmount(1000);
            Assert.AreEqual("$10.00", exercise.ToString());

            exercise = new DollarAmount(1);
            Assert.AreEqual("$0.01", exercise.ToString());
        }

        [TestMethod]
        public void ToDecimal()
        {
            DollarAmount example = new DollarAmount(1000);

            Assert.AreEqual(10.0M, example.ToDecimal());

        }

        [TestMethod]
        public void Deposit()
        {
            BankAccount account1 = new BankAccount();
            DollarAmount initialBalance = new DollarAmount(10000);
            account1.Deposit(initialBalance);

            BankAccount account2 = new BankAccount();
            DollarAmount initialBalance2 = new DollarAmount(10000);
            account2.Deposit(initialBalance2);

            Assert.AreEqual(initialBalance.ToString(), account1.Balance.ToString());
        }

        [TestMethod]
        public void Withdraw()
        {
            BankAccount account1 = new BankAccount();
            DollarAmount initialBalance = new DollarAmount(10000);

            DollarAmount withdrawnBalance = new DollarAmount(5000);

            account1.Deposit(initialBalance);
            account1.Withdraw(withdrawnBalance);

            DollarAmount expected = withdrawnBalance;

            Assert.AreEqual(expected.ToString(), account1.Balance.ToString());
        }

        [TestMethod]
        public void Transfer()
        {
            BankAccount b1 = new BankAccount();
            BankAccount b2 = new BankAccount();

            DollarAmount amountToDeposit = new DollarAmount(100);

            DollarAmount newBalance = b2.Deposit(amountToDeposit);

            DollarAmount amountToTransfer = new DollarAmount(50);

            b2.Transfer(b1, amountToTransfer);

            DollarAmount b1Expected = new DollarAmount(50);
            DollarAmount b2Expected = new DollarAmount(50);

            Assert.AreEqual(b2Expected.ToString(), b2.Balance.ToString());
            Assert.AreEqual(b1Expected.ToString(), b1.Balance.ToString());
        }

        [TestMethod]
        public void AccountNumber()
        {
            BankAccount account1 = new BankAccount();
            account1.AccountNumber = "17862";

            Assert.AreEqual("17862", account1.AccountNumber);
        }

        [TestMethod]
        public void WithdrawChecking()
        {
            //$100 - $75
            CheckingAccount example = new CheckingAccount();
            example.Deposit(new DollarAmount(10000));
            example.Withdraw(new DollarAmount(7500));
            DollarAmount expected = new DollarAmount(2500);
            Assert.AreEqual(expected.ToString(), example.Balance.ToString());

            //$100 - $110
            CheckingAccount example1 = new CheckingAccount();
            example1.Deposit(new DollarAmount(10000));
            example1.Withdraw(new DollarAmount(11000));
            DollarAmount expected1 = new DollarAmount(-2000);
            Assert.AreEqual(expected1.ToString(), example1.Balance.ToString());

            //$100 - $500
            CheckingAccount example2 = new CheckingAccount();
            example2.Deposit(new DollarAmount(10000));
            example2.Withdraw(new DollarAmount(50000));
            DollarAmount expected2 = new DollarAmount(10000);
            Assert.AreEqual(expected2.ToString(), example2.Balance.ToString());
        }

        [TestMethod]
        public void WithdrawSavings()
        {
            //$100 - $50
            SavingsAccount example = new SavingsAccount();
            example.Deposit(new DollarAmount(10000));
            example.Withdraw(new DollarAmount(5000));
            DollarAmount expected = new DollarAmount(4800);
            Assert.AreEqual(expected.ToString(), example.Balance.ToString());

            //$300 - $50
            SavingsAccount example1 = new SavingsAccount();
            example1.Deposit(new DollarAmount(30000));
            example1.Withdraw(new DollarAmount(5000));
            DollarAmount expected1 = new DollarAmount(25000);
            Assert.AreEqual(expected1.ToString(), example1.Balance.ToString());

            //$100 - $150
            SavingsAccount example2 = new SavingsAccount();
            example2.Deposit(new DollarAmount(10000));
            example2.Withdraw(new DollarAmount(15000));
            DollarAmount expected2 = new DollarAmount(10000);
            Assert.AreEqual(expected2.ToString(), example2.Balance.ToString());
        }
        [TestMethod]
        public void BankCustomer()
        {
            BankCustomer nickC = new BankCustomer();
            nickC.Name = "Nick Collins";
            nickC.Address = "1275 Kinnear Rd";
            nickC.PhoneNumber = "614-888-8888";

            CheckingAccount nicksCheckingAcct = new CheckingAccount();
            nicksCheckingAcct.Deposit(new DollarAmount(30000,00));

            nickC.AddAccount(nicksCheckingAcct);
            //Make sure Nick's Checking Account is in his Account list.
            Assert.AreEqual(nicksCheckingAcct, nickC.Accounts[0]);
            //Nicks Checking account has 30 grand in it (per usual)
            Assert.AreEqual("$30000.00", nickC.Accounts[0].Balance.ToString());
            //Making sure Nick is a VIP
            Assert.AreEqual(true, nickC.IsVIP);
        }
    }
}
