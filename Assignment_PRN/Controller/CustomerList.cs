using Assignment.Model;
using Assignment.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Controller
{
    class CustomerList
    {
        public static List<Customer> listCustomer = new List<Customer>()
        {
            new Customer()
            {
                CustomerID="1",CustomerName="Jack",CustomerAddress="USA",ListAccount=new List<Account>(){
                new Account("1",100),
                new Account("2",500),
                new Account("3",800),
                new Account("4",600)
                }
            },
            new Customer()
            {
                CustomerID="2",CustomerName="John",CustomerAddress="UK",ListAccount=new List<Account>(){
                new Account("1",800),
                new Account("2",900),
                new Account("3",10000),
                new Account("4",12323)

                }
            },
            new Customer()
            {
                CustomerID="5",CustomerName="Kate",CustomerAddress="AUSTRALIA",ListAccount=new List<Account>(){
                new Account("1",2200),
                new Account("2",13200),
                new Account("3",123),
                new Account("4",2230)
                }
            }
        };


        public static Customer checkID(String customerID)
        {
            foreach (Customer cus in listCustomer)
            {
                if (cus.CustomerID.Equals(customerID))
                {
                    return cus;
                }
            }
            return null;
        }
        public static void addCustomer(Customer customer)
        {
            do
            {

                String customerID, BranchID;
                Branch branch;
                do
                {
                    BranchList.showBranch();
                    BranchID = Inputter.validateString($"\nBranch ID: ");
                    branch = BranchList.checkDuplicateID(BranchID);
                    if (branch == null)
                    {
                        Inputter.redColor("\nNot found branch id!");
                    }
                } while (branch == null);
                do
                {
                    showCustomer();
                    Console.WriteLine("\n-----Input Customer Information-----");
                    customerID = Inputter.validateString($"Customer ID: ");
                    customer = checkID(customerID);
                    if (customer != null)
                    {
                        Inputter.redColor("Duplicate id!");
                    }
                } while (customer != null);

                String customerName = Inputter.validateString($"Customer name: ");
                String customerAddress = Inputter.validateString($"Customer address: ");
                Customer cus = new Customer(customerID, customerName, customerAddress, new List<Account>());
                listCustomer.Add(cus);
                Inputter.greenColor("Added Customer!!!!");
                Inputter.yellowColor("Do you want to continue?(y/n): ");
                String check = Console.ReadLine();
                if (check.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            } while (true);
        }

        public static void showCustomer()
        {
            if (listCustomer.Count == 0)
            {
                Console.WriteLine("\n-----Customer List------");
                Inputter.yellowColor("Customer List is empty");
            }
            else
            {
                Console.WriteLine("\n-----Customer List------");
                Console.WriteLine("{0,-10} \t{1,-20} \t\t{2,-20}", "CustomerID", "CustomerName", "CustomerAdress");
                foreach (Customer cus in listCustomer)
                {
                    Console.WriteLine("{0,-10} \t{1,-20} \t\t{2,-20}", cus.CustomerID, cus.CustomerName, cus.CustomerAddress,cus.ListAccount);
                }
            }
        }
        public static void showAllCustomer()
        {
            if (listCustomer.Count == 0)
            {
                Console.WriteLine("\n-----All Customer------");
                Inputter.yellowColor("Customer List is empty");
            }
            else
            {
                Console.WriteLine("\n-----All Customer------");
                Console.WriteLine("{0,-10} \t{1,-20} \t\t{2,-20}", "CustomerID", "CustomerName", "CustomerAdress");
                foreach (Customer cus in listCustomer)
                {
                    Console.WriteLine("{0,-10} \t{1,-20} \t\t{2,-20}", cus.CustomerID, cus.CustomerName, cus.CustomerAddress);
                }
            }
        }

        public static void displayCustomer(Branch branch)
        {
            int check = 0;
            Console.WriteLine("Branch {0}", branch.ListCustomer);
            Console.WriteLine("{0,-10} \t{1,-20} \t\t{2,-20}", "CustomerID", "CustomerName", "CustomerAddress");
            foreach (Customer cus in branch.ListCustomer)
            {
                check++;
                Console.WriteLine("{0,-10} \t{1,-20} \t\t{2,-20}", cus.CustomerID, cus.CustomerName, cus.CustomerAddress);
            }
            if (check == 0)
            {
                Inputter.redColor("No customer in this customer!!");
            }
        }

        public static void subMenuAdd(Customer customer, Account account)
        {
            bool check = true;
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" ------------------------");
                Console.WriteLine("|        Add Menu        |");
                Console.WriteLine("|                        |");
                Console.WriteLine("| 1. Add Customer        |");
                Console.WriteLine("| 2. Add Account         |");
                Console.WriteLine("| 3. Exit                |");
                Console.WriteLine("|                        |");
                Console.WriteLine(" ------------------------");
                Console.Write("Choose your option: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addCustomer(customer);
                        break;
                    case 2:
                        AccountList.addAccount(account);
                        break;
                    default:
                        check = false;
                        break;
                }
            } while (check);
        }



    }
}
