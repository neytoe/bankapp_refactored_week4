using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{
   public class BankAccount

    {

        private int accountNumber = 1234567890;

        //Constructor for the Bank
        public BankAccount(Customer customer, decimal initialDeposit, string accountType, DateTime date)
        {
            CustomerName = $"{customer.FirstName} {customer.LastName}";
            AccountNumber = accountNumber;
            AccountBalance = initialDeposit;
            AccountType = accountType;
            Date = date;
            Note = "Initial Deposit";

            AllCustomers.Add(customer);
            MakeDeposit(this, initialDeposit, DateTime.Now, "Inital Deposit");
            accountNumber++;
        }

        public string CustomerName { get; }
        public int AccountNumber { get; }
        public decimal AccountBalance { get; set; }
        public string AccountType { get; }
        public DateTime Date { get; }
        public string Note { get; }

        public List<Transactions> AllTransactions { get; set; } = new List<Transactions>();
        public List<BankAccount> AllAccounts { get; set; } = new List<BankAccount>();
        public List<Customer> AllCustomers { get; set; } = new List<Customer>();



        //Make deposit method
        public void MakeDeposit(BankAccount customer, decimal amount, DateTime date, string note)
        {
            if (amount < 1)
                throw new InvalidOperationException("Amount should be greater than 0");
            

            AccountBalance += amount;
            AllTransactions.Add(new Transactions(customer, amount, customer.AccountBalance, DateTime.Now, note));


        }

        public void MakeWithdrawal(BankAccount account, decimal amount, DateTime date, string note)
        {

            AccountBalance -= amount;
            Transactions transaction = new Transactions(account, amount, AccountBalance, date, note);
            AllTransactions.Add(transaction);
        }



    }
}
