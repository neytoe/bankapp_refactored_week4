using System;
using System.Collections.Generic;
using System.Text;

namespace bankapp_refactored_week4.ClassLibraries
{
   public class Customer
    {
        //This class holds all the properties of a typical customer
        private static int id = 1;
        public Customer(string firstName, string lastName, string email, string password)
        {
            Username = $"{firstName} {lastName}";
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UniqueId = id;
            id++;
            Password = password;
            Bank.AllCustomers.Add(this);
        }

        // public static List<Customer> AllCustomer = new List<Customer>();

        public int UniqueId { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; }

        public string Username { get; }
    }
}
