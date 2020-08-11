using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{
   public class BankAccount

    {
        private static int accountNumberSeed = 1234567890;

        public string CustomerName { get; }
        public int AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountType { get; }
        public DateTime Date { get; }
        public string Note { get; }

        //Constructor for the BankAccount
        public BankAccount(Customer customer, decimal initialDeposit, string accountType, DateTime date)
        {
            CustomerName = $"{customer.FirstName} {customer.LastName}";
            AccountNumber = accountNumberSeed;
            accountNumberSeed += 111;
            AccountType = accountType;
            Date = date;

            Note = "Initial Deposit";
            Bank.AllAccounts.Add(this);
            Bank.AllCustomers.Add(customer);
            MakeDeposit(this, initialDeposit, DateTime.Now, "Inital Deposit");
        }



        /* The Make deposit method 
         * ensures that the amount to be deposited is greater than one
         * before the transaction can be consumated
         */
        public void MakeDeposit(BankAccount customer, decimal amount, DateTime date, string note)
        {

            if (amount < 1)
                throw new InvalidOperationException("Amount should be greater than 0");
            

            AccountBalance += amount;
            Bank.AllTransactions.Add(new Transactions(customer, amount, customer.AccountBalance, DateTime.Now, note));


        }


        /*This methods handles withdrawal
         *it checks if the account is savings or current and checks
         * for the necessary conditions before the transaction
         * can be consumated
         */
        public void MakeWithdrawal(BankAccount account, decimal amount, DateTime date, string note)
        {
            if (amount < 1)
                throw new InvalidOperationException("Amount should be greater than 0");

            if (account.AccountType == "savings" && account.AccountBalance - amount < 100)
                throw new InvalidOperationException("Balance must be at least 100naira for savings");

            if (account.AccountType == "current" && account.AccountBalance - amount < 0)
                throw new InvalidOperationException("Balance must be at least 1000naira for current");


            AccountBalance -= amount;
            Transactions transaction = new Transactions(account, amount, AccountBalance, date, note);
            Bank.AllTransactions.Add(transaction);
        }



        //The transfer method
        public void Transfer (BankAccount recipient, decimal amount, DateTime date, string note)
        {
          
            
            foreach (var acct in Bank.AllAccounts)
            {
                if (this.AccountNumber.Equals(recipient.AccountNumber))
                {
                    throw new InvalidOperationException("Cannot Transfer to the same account");
                }

                if (acct.AccountNumber.Equals(recipient.AccountNumber))
                {
                    MakeWithdrawal(this, amount, DateTime.Now, note);
                    recipient.MakeDeposit(recipient, amount, DateTime.Now, note);
                    Console.WriteLine($"You have successfully transferred {amount}naira to {recipient.CustomerName} on {date} \n and your balance is {this.AccountBalance}" );
                    break;
                }

            }
        }




    }
}
