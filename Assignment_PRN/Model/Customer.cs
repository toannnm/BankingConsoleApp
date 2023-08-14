using Assignment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    class Customer
    {
        String customerID;
        String customerName;
        String customerAddress;
        List<Account> listAccount;
        AccountList accounts;

        public AccountList Accounts { get => accounts; set => accounts = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        internal List<Account> ListAccount { get => listAccount; set => listAccount = value; }

        public Customer(string customerID, string customerName, string customerAddress, List<Account> listAccount)
        {
            this.CustomerID = customerID;
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.ListAccount = listAccount;
        }

        public Customer(string customerID, string customerName, string customerAddress)
        {
            this.customerID = customerID;
            this.customerName = customerName;
            this.customerAddress = customerAddress;
        }


        public Customer(string customerID, string customerName, string customerAddress, AccountList accounts)
        {
            this.CustomerID = customerID;
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.accounts = accounts;
        }

        public Customer(string customerName, string customerAddress, AccountList accounts)
        {
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.accounts = accounts;
        }

        public Customer()
        {
            listAccount = new List<Account>();
             accounts = new AccountList();
        }
        public Customer InputCustomer()
        {
            Console.WriteLine("\nInput customer's infomation");
            Console.WriteLine("Customer Name: ");
            this.CustomerName = Console.ReadLine();
            this.CustomerAddress = Console.ReadLine();
            this.accounts = new AccountList();
            return this;

        }

        public override string? ToString()
        {
            return $"\n- Customer ID: {this.CustomerID}  " +
                   $"- Customer name: {this.CustomerName}" +
                   $"- Customer address: {this.CustomerAddress}";
        }
    }
}
