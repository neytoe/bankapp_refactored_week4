using bankapp_refactored_week4.ClassLibraries;
using System;
using System.Runtime.CompilerServices;

namespace bankapp_refactored_week4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cus = new Customer("netochukwu", "Anyankah", "nany@gmail.com", "1996");
            var acc = new BankAccount(cus, 1000, "savings", DateTime.Now);

            acc.MakeDeposit(acc, -1, DateTime.Now, "deposit");

            Console.WriteLine(cus.FirstName);
        }
    }
}
