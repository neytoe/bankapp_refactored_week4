using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace bankapp_refactored_week4.Testprojects
{
    [TestFixture]
    public class WithdrawalTest
    {
        
        [Test]
        public void whenAmountTobeWithdrawnIsMoreThanBalance()
        {
            //Arrange
            var cust = new Customer("neto", "jide", "nanyaa@gmail.com", "9999");
            var acct = new BankAccount(cust, 2000, "savings", DateTime.Now);
            

            //Act


            //Assert

        }

        [Test]
        public void withdrawalReflects()
        {
            //Arrange
            var cust = new Customer("neto", "jide", "nanyaa@gmail.com", "9999");
            var acct = new BankAccount(cust, 2000, "savings", DateTime.Now);
            decimal Balance = acct.AccountBalance;

            //Act
            acct.MakeWithdrawal(acct, 1000, DateTime.Now, "withdrawal");

            //Assert
            Assert.That(acct.AccountBalance, Is.EqualTo(Balance - 1000));
        }

    }
}
