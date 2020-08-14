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

            var customer = new Customer("neto", "ibe", "na@gmail.com", "1996");
            var customer2 = new Customer("ze", "phi", "na@gmail.com", "1996");
            Bank.Register(customer, 10000, "savings", DateTime.Now);
            Bank.Register(customer2, 10000, "savings", DateTime.Now);
            Bank.Login("neto ibe", "1996");











        }
    }
}
