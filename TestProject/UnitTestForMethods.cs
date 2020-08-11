using bankapp_refactored_week4.ClassLibraries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;



namespace bankapp_refactored_week4.Testprojects
{
    [TestFixture]
    public class UnitTestForMethods
    {
        //Instantating Customers for the test methods
        Customer customer1 = new Customer("Netochukwu", "Anyankah", "yan@gmail.com", "1998");
        Customer customer2 = new Customer("Yadi", "Anyankah", "anyan@gmail.com", "1999");
        Customer customer3 = new Customer("Jide", "Anyankah", "janyan@gmail.com", "1999");
        Customer customer4 = new Customer("Rimz", "Anyankah", "aRnyan@gmail.com", "1999");

        [Test]
        #region Test the MakeDeposit Method
        //This tests checks that the amount to be deposited is greater than zero

        public void whenAmountToBeDepositedIsNegative()
        {
            //Arrange
             var acc = new BankAccount(customer1, 1000, "savings", DateTime.Now);

            //Act
            //acc.MakeDeposit(acc, -1, DateTime.Now, "deposit");
            
            //Assert
            Assert.Throws<InvalidOperationException>(
                () => acc.MakeDeposit(acc, -1, DateTime.Now, "deposit")
                );
        }
        
        [Test]
        //This test confirms if the deposit actually impacts the customers account
        public void TestIfdepositReflects()
        {
            //Arrange
            var acc = new BankAccount(customer1, 1000, "savings", DateTime.Now);
            decimal balance = acc.AccountBalance;
            
            
            //Act
            acc.MakeDeposit(acc, 1000, DateTime.Now, "deposit");


            //Assert
            Assert.That(acc.AccountBalance, Is.EqualTo(balance + 1000));
        }

        #endregion


        [Test]
        #region Test the Transfer method
        //This Tests that the Beneficiary received the transferred funds
        public void testThatBeneficiaryWasCredited()
        {
            //Arrange-----
            var AcctHolder = new BankAccount(customer1, 5000, "savings", DateTime.Now);
            var Beneficiary = new BankAccount(customer2, 1000, "savings", DateTime.Now);
            decimal BeneficiaryBalance = Beneficiary.AccountBalance;
            //Act
            AcctHolder.Transfer(Beneficiary, 2000, DateTime.Now, "Transfer");

            //Assert
            Assert.That(Beneficiary.AccountBalance, Is.EqualTo(BeneficiaryBalance + 2000));


        }


        [Test]
        //This test verifies that the initiator of the transfer was debited
        public void testThatAccountHolderWasDebited()
        {
            //Arrange-----
            var AcctHolder = new BankAccount(customer1, 5000, "savings", DateTime.Now);
            var Beneficiary = new BankAccount(customer2, 1000, "savings", DateTime.Now);
            decimal AcctHolderBalance = AcctHolder.AccountBalance;
            //Act
            AcctHolder.Transfer(Beneficiary, 2000, DateTime.Now, "Transfer");

            //Assert
            Assert.That(AcctHolder.AccountBalance, Is.EqualTo(AcctHolderBalance - 2000));
            Console.WriteLine(AcctHolderBalance);

        }
        #endregion


        [Test]
        #region Test the MakeWithdrawalMethod
        //This test verifies that a savings acct withdraw but leave a balance of 100naira
        public void whenAmountTobeWithdrawnIsMoreThanBalanceForSavings()
        {
            //Arrange
            var acct = new BankAccount(customer1, 4000, "savings", DateTime.Now);
            decimal Balance = acct.AccountBalance;

            //Act


            //Assert
            Assert.Throws<InvalidOperationException>(
            () => acct.MakeWithdrawal(acct, 4000, DateTime.Now, "withdrawal")
            );

        }


        [Test]
        //This test confirms that a current acct can withdraw all the funds but can't leave a negative balance
        public void whenAmountTobeWithdrawnIsMoreThanBalanceForCurrent()
        {
            //Arrange
            var acct = new BankAccount(customer1, 4000, "current", DateTime.Now);
            decimal Balance = acct.AccountBalance;

            //Act


            //Assert
            Assert.Throws<InvalidOperationException>(
            () => acct.MakeWithdrawal(acct, 4001, DateTime.Now, "withdrawal")
            );

        }



        [Test]
        //This test confirms that the initiator of the account was debited
        public void withdrawalReflects()
        {
            //Arrange
            var acct = new BankAccount(customer1, 2000, "savings", DateTime.Now);
            decimal Balance = acct.AccountBalance;

            //Act
            acct.MakeWithdrawal(acct, 1000, DateTime.Now, "withdrawal");

            //Assert
            Assert.That(acct.AccountBalance, Is.EqualTo(Balance - 1000));
        }
        #endregion

    
        [Test]
        #region Test various Transaction Methods

        //This tests that transactions initiated are stored in List of AllTransactions
        public void AllTransactionsAreRecorded()
        {
            //int initialLength = Bank.AllTransactions.Count;
            Console.WriteLine(Bank.AllTransactions.Count);
            //Arrange
            var acct = new BankAccount(customer1, 2000, "savings", DateTime.Now);
            var acct2 = new BankAccount(customer2, 4000, "savings", DateTime.Now);
            var acct3 = new BankAccount(customer3, 5000, "savings", DateTime.Now);
            var acct4 = new BankAccount(customer4, 8000, "savings", DateTime.Now);

            Console.WriteLine(Bank.AllTransactions.Count);
            //Act
            acct.MakeWithdrawal(acct, 1000, DateTime.Now, "withdrawal");
            acct2.MakeDeposit(acct2, 400, DateTime.Now, "deposit");
            acct3.Transfer(acct4, 2000, DateTime.Now, "Transfer");

            int ListLength = Bank.AllTransactions.Count;
            //int newTrans = ListLength - initialLength;


            //Assert
            Assert.That(ListLength, Is.EqualTo(8));
            
        }
        #endregion


        [Test]
        #region Test the registration Method
        //This method verifies that only registered accounts exist
        
        public void ARegisteredAccountIsInTheDataBase()
        {
            //Arrange
            //Register an account for customer 1
            Bank.Register(customer1, 1200, "savings", DateTime.Now);
            var acct = new BankAccount(customer1, 2000, "savings", DateTime.Now);
            //ASSERT
            //Confirming account detail for registered customer doesn't return null
            Assert.That(Bank.GetCustomerAccount(acct.AccountNumber), Is.Not.EqualTo(null));
        }

        [Test]
        //This test verifies that accounts not registered don't exist
        public void ANonRegisteredaccountIsNotInTheDataBase()
        {
            // Arrange
            int AnyAccountNumber = 1234567456;

            //Act

            //Assert
            /*The GetCustomerAcccount method loops through the AllAccounts List to verify the random
              Account number doesn't exist.*/
            Assert.That(Bank.GetCustomerAccount(AnyAccountNumber), Is.EqualTo(null));
        }
        #endregion

        [Test]
        #region Test the Login Method
        public void checkThatCustomerSuccessfullyLoggedIn()
        {
            //Arrange
            //Already instantiated Customer
            Customer customer1 = new Customer("Netochukwu", "Anyankah", "yan@gmail.com", "1998");

            //Act
            Bank.Login(customer1.Username, customer1.Password);


            //Assert
            Assert.That(Bank.LoggedInUser[0].Username, Is.EqualTo("Netochukwu Anyankah"));
        }

        [Test]
        public void checkThatNonExistingCustomerFailedToLoggedIn()
        {
            //Arrange
           

            //Act
            //Using non-existent random customer
           


            //Assert
            Assert.Throws<NullReferenceException>(
               () => Bank.Login("No Name", "419")
           );
            
        }
        #endregion
    }
}
