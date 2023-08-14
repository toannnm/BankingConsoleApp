using Assignment.Model;
using Assignment.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Controller
{
    class AccountList
    {
        private static List<Account> listAccount = new List<Account>()
        {
           new Account("1",100,new Customer("1","Jack","USA")),
                new Account("2",500,new Customer("1","Jack","USA")),
                new Account("3",800, new Customer("1", "Jack", "USA")),
                new Account("4",600, new Customer("1", "Jack", "USA")),
                new Account("1",800, new Customer("2", "Jonh", "UK")),
                new Account("2",900,new Customer("2", "Jonh", "UK")),
                new Account("3",10000,new Customer("2", "Jonh", "UK")),
                new Account("4",12323,new Customer("2", "Jonh", "UK")),
                new Account("1",2200,new Customer("5", "Kate", "AUSTRALIA")),
                new Account("2",13200,new Customer("5", "Kate", "AUSTRALIA")),
                new Account("3",123,new Customer("5", "Kate", "AUSTRALIA")),
                new Account("4",2230, new Customer("5", "Kate", "AUSTRALIA"))
        };

        public void addToList(Account account)
        {
            listAccount.Add(account);
        }

        public static Account checkID(String accountID)
        {
            foreach (Account acc in listAccount)
            {
                if (acc.AccountID.Equals(accountID))
                {
                    return acc;
                }
            }
            return null;
        }

        public static Account CheckAccountIDInCustomer(Customer customer, String accountID)
        {
            foreach (Account acc in customer.ListAccount)
            {
                if (acc.AccountID.Equals(accountID))
                {
                    return acc;
                }
            }
            return null;
        }


        public static void FindHighestRemainder()
        {
            var highestRemainder = CustomerList.listCustomer.GroupJoin(
                listAccount,
                c => c.CustomerID,
                a => a.Customer.CustomerID,
                (c, a) => new
                {
                    CustomerId = c.CustomerID,
                    CustomerName = c.CustomerName,
                    account = a,
                    listaccount = a.Where(x => x.Remainder == a.Max(y => y.Remainder))
               .Select(x => new
               {
                   AccountId = x.AccountID,
                   Remainder = x.Remainder,
                   listTransactions = x.listTransaction?
                   .Select(
                           t => new
                           {
                               transactionId = t.TransactionID,
                               transactionDate = t.TransactionDate,
                               money = t.Money,
                               transactionType = t.TransactionType
                           })
               })
                });
            foreach (var item in highestRemainder)
            {
                Console.WriteLine($"CustomerId:{item.CustomerId}_Welcome:{item.CustomerName} ");
                foreach (var item1 in item.listaccount)
                {
                    Console.WriteLine($"AccountId:{item1.AccountId}_Balance:{item1.Remainder}");
                    if (TransactionList.listTransaction is not null)
                    {
                        var accountTransaction = TransactionList.listTransaction.Where(t => t.Account.AccountID == item1.AccountId);
                        foreach (var t in accountTransaction)
                        {
                            Console.WriteLine($"\nTransactionId:{t.TransactionID} \nDatetime:{t.TransactionDate} \nMoney:{t.Money} \nTransactionType:{t.TransactionType} \nAccountID:{t.Account.AccountID}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No transaction");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void Sort()
        {
            var sortRemainderByEachCustomer = CustomerList.listCustomer.GroupJoin(
                listAccount, c => c.CustomerID, a => a.Customer.CustomerID,
                (c, a) => new
                {
                    customer = c,
                    total = a.Sum(a => a.Remainder)
                }
                ).OrderByDescending(x => x.total);
            foreach (var item in sortRemainderByEachCustomer)
            {
                Console.WriteLine($"CustomerID: {item.customer.CustomerID} CustomerName:{item.customer.CustomerName} CustomerAddress:{item.customer.CustomerAddress}");

                var customerAccounts = listAccount.Where(a => a.Customer.CustomerID == item.customer.CustomerID);

                foreach (var account in customerAccounts)
                {
                    Console.WriteLine($"Account ID: {account.AccountID}, Remainder: {account.Remainder}");
                }
            }
        }
        public static void FindCustomerWithMostTransactions()
        {
            var customerTransactionCounts = CustomerList.listCustomer
    .Join(listAccount, customer => customer.CustomerID, account => account.Customer.CustomerID, (customer, account) => new { customer, account })
    .Join(TransactionList.listTransaction, account => account.account.AccountID, transaction => transaction.Account?.AccountID, (account, transaction) => new
    {
        account.customer,
        transaction
    })
    .Where(x => x.transaction.Account != null)
    .GroupBy(x => x.customer)
    .Select(customerTransactions => new
    {
        Customer = customerTransactions.Key,
        TransactionCount = customerTransactions.Count()
    });
            var customerWithMostTransactions = customerTransactionCounts.OrderByDescending(c => c.TransactionCount).FirstOrDefault();

            if (customerWithMostTransactions != null)
            {
                Console.WriteLine($"Customer with most transactions: {customerWithMostTransactions.Customer.CustomerName}, Total transactions: {customerWithMostTransactions.TransactionCount}");
            }
            else
            {
                Console.WriteLine("No customers found.");
            }
        }

        public Account getAccountByID(String accID)
        {
            Console.WriteLine("Account ID: ");
            accID = Console.ReadLine();
            foreach (Account acc in AccountList.listAccount)
            {
                if (acc.AccountID == accID)
                {
                    return acc;
                }
            }
            return null;
        }
        public static void addAccount(Account account)
        {
            do
            {
                Customer customer;
                String accountID, customerID;

                do
                {
                    CustomerList.showAllCustomer();
                    customerID = Inputter.validateString("\nEnter CustomerID: ");
                    customer = CustomerList.checkID(customerID);
                    if (customer == null)
                    {
                        Inputter.redColor("\nCustomer ID is not exist!");
                    }
                } while (customer == null);
                Console.WriteLine($"Welcome:  {customer.CustomerName}");
                do
                {
                    ShowAll();
                    Console.WriteLine($"\n-----Input Account Information-----");
                    accountID = Inputter.validateString("\nEnter AccountID: ");
                    account = checkID(accountID);
                    if (account != null)
                    {
                        Inputter.redColor("Duplicate id!");
                    }
                } while (account != null);

                decimal remainder;
                Account current = new Account(accountID, new List<Transaction>());
                listAccount.Add(current);
                customer.ListAccount.Add(current);
                Inputter.greenColor("\nAdded Account!!!!");
                Console.WriteLine("\nCustomer info\n" +
                      $"+ Customer ID: {customer.CustomerID} -- Customer name: {customer.CustomerName} -- Customer address: {customer.CustomerAddress} \n");
                Console.WriteLine("Account info\n" +
                 $"+ Account ID: {current.AccountID} -- Remainder: {current.Remainder}\n");
                Inputter.yellowColor("Do you want to continue?(y/n): ");
                String check = Console.ReadLine();
                if (check.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            } while (true);
        }
        public static void ShowCustomerByID(string customerID)
        {
            var showAll = CustomerList.listCustomer
                .Where(c => c.CustomerID == customerID)
     .GroupJoin(listAccount, customer => customer.CustomerID, account => account.Customer.CustomerID,
         (customer, accounts) => new
         {
             customer,
             accounts
         })
     .SelectMany(x => x.accounts, (x, account) => new
     {
         x.customer,
         account
     })
     .GroupJoin(TransactionList.listTransaction, x => x.account?.AccountID, transaction => transaction.Account?.AccountID,
         (account, transactions) => new
         {
             account.customer,
             account.account,
             transactions
         })
     .Select(x => new
     {
         Customer = x.customer,
         Transactions = x.transactions.Where(t => t != null && t.Account?.AccountID == x.account?.AccountID),
         Account = x.account
     });
            var customer = showAll.FirstOrDefault(item => item.Customer.CustomerID == customerID);
            if (customer is not null)
            {
                Console.WriteLine($"Welcome customer: {customer.Customer.CustomerName}");
            }
            Console.WriteLine();
            foreach (var item in showAll)
            {
                if (item.Account is not null)
                {
                    Console.WriteLine($"Account ID: {item.Account.AccountID},Balance: {item.Account.Remainder}");
                }
                else
                {
                    Console.WriteLine("No account found for this customer.");
                }
                if (item.Transactions.Any())
                {
                    Console.WriteLine("Transactions:");

                    foreach (var transaction in item.Transactions)
                    {
                        Console.WriteLine($"  Transaction ID: {transaction.TransactionID}, Date: {transaction.TransactionDate}, Amount:{transaction.Money} , Type:{transaction.TransactionType}");
                    }
                }
                else
                {
                    Console.WriteLine("No transactions found for this customer.");
                }
                Console.WriteLine();
            }

        }
        public static void ShowAll()
        {
            //       var showAll = CustomerList.listCustomer
            //.GroupJoin(listAccount, customer => customer.CustomerID, account => account.Customer.CustomerID,
            //    (customer, accounts) => new
            //    {
            //        customer,
            //        accounts
            //    })
            //.SelectMany(x => x.accounts, (x, account) => new
            //{
            //    x.customer,
            //    account
            //})
            //.GroupJoin(TransactionList.listTransaction, x => x.account?.AccountID, transaction => transaction.Account?.AccountID,
            //    (account, transactions) => new
            //    {
            //        account.customer,
            //        account.account,
            //        transactions
            //    })
            //.Select(x => new
            //{
            //    Customer = x.customer,
            //    Transactions = x.transactions.Where(t => t != null && t.Account?.AccountID == x.account?.AccountID),
            //    Account = x.account
            //});
            foreach (var item in CustomerList.listCustomer)
            {
                Console.WriteLine($"Customer ID: {item.CustomerID}, Customer Name: {item.CustomerName}");
                var CustomerAccount = listAccount.Where(a => a.Customer.CustomerID == item.CustomerID);
                if (CustomerAccount.Any())
                {
                    foreach (var account in CustomerAccount)
                    {
                        Console.WriteLine($"Account ID: {account.AccountID},Balance: {account.Remainder}");
                        //var accountTransactions = TransactionList.listTransaction.Where(transaction => transaction.Account?.AccountID == account.AccountID);
                        //if (accountTransactions.Any())
                        //{
                        //    Console.WriteLine("Transactions");
                        //    foreach (var transaction in accountTransactions)
                        //    {
                        //        Console.WriteLine($"  Transaction ID: {transaction.TransactionID}, Date: {transaction.TransactionDate}, Amount:{transaction.Money} , Type:{transaction.TransactionType}");
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("No transactions found for this customer.");
                        //}
                    }


                }
                else
                {
                    Console.WriteLine("No account found for this customer.");
                }

                //    foreach (var item in showAll)
                //    {
                //        Console.WriteLine($"Customer ID: {item.Customer.CustomerID}, Customer Name: {item.Customer.CustomerName}");
                //        if (item.Account is not null)
                //        {
                //            Console.WriteLine($"Account ID: {item.Account.AccountID},Balance: {item.Account.Remainder}");
                //        }
                //        else
                //        {
                //            Console.WriteLine("No account found for this customer.");
                //        }

                //        if (item.Transactions.Any())
                //        {
                //            Console.WriteLine("Transactions:");

                //            foreach (var transaction in item.Transactions)
                //            {
                //                Console.WriteLine($"  Transaction ID: {transaction.TransactionID}, Date: {transaction.TransactionDate}, Amount:{transaction.Money} , Type:{transaction.TransactionType}");
                //            }
                //        }
                //        else
                //        {
                //            Console.WriteLine("No transactions found for this customer.");
                //        }

                //        Console.WriteLine();
                //    }
                //    Console.WriteLine();
                //}

            }
        }
    }
}






