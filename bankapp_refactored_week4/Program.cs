using bankapp_refactored_week4.ClassLibraries;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace bankapp_refactored_week4
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Print Customers");
            //BankAccount.PrintCustomers();
            //Console.WriteLine("insert log in details");
            //string username = Console.ReadLine();
            //string password = Console.ReadLine();
            ////var Banky = new Bank();
            //Bank.Login(username, password);

            //Bank.GetAllLoggedInUsers();





            var cus1 = new Customer("tochukwu", "Anyankah", "nany@gail.com", "1997");
            Bank.Login(cus1.Username, cus1.Password);
            Bank.GetAllLoggedInUsers();
            var cus3 = new Customer("nechukwu", "Anyankah", "nany@gail.com", "1998");
            Bank.Login(cus3.Username, cus3.Password);
            Bank.GetAllLoggedInUsers();
            var cus = new Customer("netochukwu", "Anyankah", "nany@gmail.com", "1996");
            Bank.Login(cus.Username, cus.Password);

            Bank.GetAllLoggedInUsers();


            //var cus1 = new Customer("tochukwu", "Anyankah", "nany@gail.com", "1997");
            //var cus3 = new Customer("nechukwu", "Anyankah", "nany@gail.com", "1998");



            //var Banky = new BankAccount(cus, 200, "savings", DateTime.Now);
            //Banky.MakeWithdrawal(Banky, 100, DateTime.Now, "withdrawal");
            //Bank.GetAllTransactions();
            //Banky.MakeDeposit(Banky, 300, DateTime.Now, "Pay");
            //var Bank1 = new BankAccount(cus1, 2000, "savings", DateTime.Now);
            //var Bank2 = new BankAccount(cus3, 200, "savings", DateTime.Now);
            //Bank1.Transfer(Banky, 1000, DateTime.Now, "transfer");
            //Thread.Sleep(1000);

            //var customer = new Customer("Jude", "Bellingham", "j@mail.com", "pass123");
            //Thread.Sleep(1000);

            //Bank.Register(customer, 900, "current", DateTime.Now);

            //Thread.Sleep(1000);
            //Console.WriteLine("Print Accounts");
            //Bank.GetAllAccounts();
            //Thread.Sleep(1000);

            //    Console.WriteLine("Print Customers");
            //    BankAccount.PrintCustomers();



            //    Console.WriteLine("print Transactions");
            //    BankAccount.PrintTransactions();




        }
    }
}
