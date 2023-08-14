using Assignment.Controller;
using Assignment.Model;
using Assignment.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            bool cont = false;
            Branch branch = new Branch();
            Customer customer = new Customer();
            Account account = new Account();
            Transaction transaction = new Transaction();
            do
            {
                Console.WriteLine($"\n|-----------------------------    Menu   -------------------------------------|");
                Console.WriteLine($"-------------------------------------------------------------------------------");
                Console.WriteLine($"|        1. Add Customer or add Account                                       |");
                Console.WriteLine($"|        2. Display Customer information                                      |");
                Console.WriteLine($"|        3. Make a transaction(deposit)                                       |");
                Console.WriteLine($"|        4. Make a transaction(withdraw)                                      |");
                Console.WriteLine($"|        5. Display transaction of Account and Customer                       |");
                Console.WriteLine($"|        6. Show all accounts have highest remainder                          |");
                Console.WriteLine($"|        7. Sort ascending remainder Customer                                 |");
                Console.WriteLine($"|        8. Show Customer has highest transaction times                       |");
                Console.WriteLine($"|        9. Exit                                                              |");
                Console.WriteLine($"-------------------------------------------------------------------------------");
                choice = Inputter.validateNumInt("Enter your choice: ");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        CustomerList.subMenuAdd(customer, account);
                        break;
                    case 2:
                        Console.Clear();
                        AccountList.ShowAll();
                        break;
                    case 3:
                        Console.Clear();
                        TransactionList.deposit();
                        break;
                    case 4:
                        Console.Clear();
                        TransactionList.withdraw();
                        break;
                    case 5:
                        Console.Clear();
                        TransactionList.showTransaction();
                        break;
                    case 6:
                        Console.Clear();
                        AccountList.FindHighestRemainder();
                        break;
                    case 7:
                        Console.Clear();
                        AccountList.Sort();
                        break;
                    case 8:
                        Console.Clear();
                        AccountList.FindCustomerWithMostTransactions();
                        break;
                    default: return;
                }
            } while (!cont);
        }
    }
}
