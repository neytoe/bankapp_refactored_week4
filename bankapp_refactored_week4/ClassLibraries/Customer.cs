using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{
   public class Customer
    {
        private static int id = 1;
        public Customer(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UniqueId = id;
            id++;
            Password = password;
            AllCustomer.Add(this);
        }

        public static List<Customer> AllCustomer = new List<Customer>();

        public int UniqueId { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; }
    }
}
