using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace bankapp_refactored_week4.Testprojects
{
    [TestFixture]
    public class DepositTest
    {

        [Test]
        public void whenAmountToBeDepositedIsNegative()
        {
            //Arrange
            var cus = new Customer("netochukwu", "Anyankah", "nany@gmail.com", "1996");
            var acc = new BankAccount(cus, 1000, "savings", DateTime.Now);

            //Act
            //acc.MakeDeposit(acc, -1, DateTime.Now, "deposit");
            
            //Assert
            Assert.Throws<InvalidOperationException>(
                () => acc.MakeDeposit(acc, -1, DateTime.Now, "deposit")
                );
        }

        [Test]
        public void depositReflects()
        {
            //Arrange
            var cus = new Customer("netochukwu", "Anyankah", "nany@gmail.com", "1996");
            var acc = new BankAccount(cus, 1000, "savings", DateTime.Now);
            decimal balance = acc.AccountBalance;
            //Act
            
            acc.MakeDeposit(acc, 1000, DateTime.Now, "deposit");


            //Assert
            Assert.That(acc.AccountBalance, Is.EqualTo(balance + 1000));
        }


    }
}
