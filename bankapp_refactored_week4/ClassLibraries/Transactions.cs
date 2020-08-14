using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{
    public class Transactions
    {
        //this class holds the properties of a typical transaction
        public decimal Amount { get; }
        public string transactionType { get; }
        public string note { get; }
        public DateTime date { get; }
        public int AccountNo { get; }

        public string CustomerName { get; set; }
        public string AccountType { get; }

        public decimal AccountBalance { get; set; }

        public Transactions(BankAccount customer, decimal amount, decimal balance, DateTime date, string note)
        {
            AccountNo = customer.AccountNumber;
            CustomerName = customer.CustomerName;
            AccountType = customer.AccountType;
            Amount = amount;
            this.note = note;
            this.date = date;
            AccountBalance = amount;
        }
       
    }
}
