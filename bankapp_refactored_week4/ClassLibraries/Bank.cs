using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{
    public  class Bank
    {
        //Properties of the bank app
        public static List<Transactions> AllTransactions { get; set; } = new List<Transactions>();
        public static List<Customer> AllCustomers { get; set; } = new List<Customer>();
        public static List<BankAccount> AllAccounts { get; set; } = new List<BankAccount>();

        public static List<Customer> LoggedInUser { get; set; } = new List<Customer>();

        public static void Register(Customer customer, decimal initialDeposit, string accountType, DateTime date) => 
                new BankAccount(customer, initialDeposit, accountType, date);

        public static void Login(string name, string password)
        {

            //Looping through the List of Allcustomers to check if the user exists
            //for (var i = 0; i < AllCustomers.Count; i++)
            //{
            //        if ((AllCustomers[i].Username == name) && (AllCustomers[i].Password == password))
            //        { 
            //            LoggedInUser.Add(AllCustomers[i]);
            //         Console.WriteLine("Customer successfully logged in");

            //         }

            //}
            var check = AllCustomers.Find(x => x.Username == name && x.Password == password);

            if(check != null)
            {
                LoggedInUser.Add(check);
                Console.WriteLine("Customer successfully logged in");
            } else
            {
                throw new NullReferenceException("Invalid Login Details");
            }
        }

        //GetAllLoggedInUsers method gets all accounts that are currently logged in.
        public static void GetAllLoggedInUsers()
        {
            foreach (var user in LoggedInUser)
            {
                Console.WriteLine($"{user.Username}  {user.Password}");
            }
        }


        //GetAllCustomers method gets all customers that has been created in the bank
        public static void GetAllCustomers()
        {
            foreach (var customer in Bank.AllCustomers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}  {customer.UniqueId} {customer.Email} {customer.Password} ");
            }
        }


        //GetAllAccounts method gets all accounts that has been registered in the bank
        public static void GetAllAccounts()
        {
            foreach (var accounts in Bank.AllAccounts)
            {
                Console.WriteLine($"{accounts.CustomerName} {accounts.AccountType}  {accounts.AccountNumber} {accounts.AccountBalance}");
            }
        }


        //GetAllTransactions method gets all transactions that has occured in the bank
        public static void GetAllTransactions()
        {
            foreach (var transaction in Bank.AllTransactions)
            {
                Console.WriteLine($"{transaction.AccountNo} {transaction.AccountBalance}  {transaction.AccountType} {transaction.note} {transaction.date}");
            }
        }

        public static BankAccount GetCustomerAccount(int accountNumber)
        {
            BankAccount customerAccount = null;
            foreach (var account in AllAccounts)
            {
                if (accountNumber == account.AccountNumber)
                    customerAccount = account;
            }
            return customerAccount;
        }
    }
}
