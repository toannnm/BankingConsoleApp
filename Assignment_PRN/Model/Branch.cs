using Assignment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    class Branch
    {
        string brandID;
        string branchName;
        string brandAddress;
        CustomerList customers;
        List<Customer> listCustomer;
        public string BrandID { get => brandID; set => brandID = value; }
        public string BranchName { get => branchName; set => branchName = value; }
        public string BrandAddress { get => brandAddress; set => brandAddress = value; }
        public CustomerList Customers { get => customers; set => customers = value; }
        public List<Customer> ListCustomer { get => listCustomer; set => listCustomer = value; }

        public override string? ToString() => "\n***Branch Info***\n" +
                                        $"- Branch ID: {this.brandID}\n" +
                                        $"- Branch name: {this.branchName}\n" +
                                        $"- Branch address: {this.brandAddress}\n";


        public Branch InputBranch()
        {
            Console.WriteLine("\n-- Input branch's infomation --");
            Console.WriteLine("Branch Name: ");
            this.branchName = Console.ReadLine();
            Console.WriteLine("Branch Address: ");
            this.BrandAddress = Console.ReadLine();
            return this;
        }


        public Branch(string brandID, string branchName, string brandAddress, CustomerList customers)
        {
            this.brandID = brandID;
            this.branchName = branchName;
            this.brandAddress = brandAddress;
            this.customers = customers;
        }
        public Branch(string branchName, string brandAddress, CustomerList customers)
        {
            this.branchName = branchName;
            this.brandAddress = brandAddress;
            this.customers = customers;
        }

        public Branch(string brandID, string branchName, string brandAddress, List<Customer> listCustomer)
        {
            this.brandID = brandID;
            this.branchName = branchName;
            this.brandAddress = brandAddress;
            this.listCustomer = listCustomer;
        }

        public Branch()
        {
        }
    }
}