using Assignment.Model;
using Assignment.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Controller
{
    class TransactionList
    {

        public static List<Transaction> listTransaction = new List<Transaction>();
        public static Transaction checkID(int transactionID)
        {
            foreach (Transaction trans in listTransaction)
            {
                if (trans.TransactionID == transactionID)
                {
                    return trans;
                }
            }
            return null;
        }
        public static void displayTransaction(Account account)
        {
            int check = 0;
            Console.WriteLine($"AccountID:{account.AccountID}\t ");
            foreach (Transaction trans in account.listTransaction)
            {
                check++;
                Console.WriteLine(trans);
            }
            if (check == 0)
            {
                Console.WriteLine("No Transaction in this account!!");
            }
        }
        public static void showTransaction()
        {
            if (listTransaction.Count == 0)
            {
                Inputter.yellowColor("Transaction List is empty");
            }
            else
            {
                Console.WriteLine("\t\t\t-----Transaction List------");
                foreach (Transaction trans in listTransaction)
                {
                    Console.WriteLine(trans);
                }
            }
        }

        public static void addToList(Transaction transaction)
        {
            listTransaction.Add(transaction);
        }

        public static void withdraw()
        {
            CustomerList.showCustomer();
            String customerID, AccountID;
            Customer customer;
            Account account;
            Transaction transaction;
            do
            {
                customerID = Inputter.validateString($"Customer ID: ");
                customer = CustomerList.checkID(customerID);
                if (customer == null)
                {
                    Inputter.redColor("\nNot found customer id!");
                }
            } while (customer == null);
            do
            {
                Console.WriteLine("Input AccountID to begin");
                AccountID = Inputter.validateString($"\nAccount ID: ");
                account = AccountList.CheckAccountIDInCustomer(customer, AccountID);
                if (account == null)
                {
                    Inputter.redColor("\nNot found account id!");
                }
            } while (account == null);
            decimal money = Inputter.validateNumInt("Input money to Withdraw: ");
            Transaction trans = new Transaction(DateTime.Now, money, "W", account);
            if (trans.Money <= account.Remainder)
            {
                Inputter.greenColor("Withdraw success!!!!");
                account.MakePurchase(customer, trans.Money);
                TransactionList.addToList(trans);
                account.listTransaction.Add(trans);
                displayTransaction(account);
            }
            else
            {
                Inputter.redColor("Withdraw fail!!!!");
            }
        }

        public static void deposit()
        {
            CustomerList.showCustomer();
            String customerID, AccountID;
            Customer customer;
            Account account;
            Transaction transaction;
            do
            {
                customerID = Inputter.validateString($"Customer ID: ");
                customer = CustomerList.checkID(customerID);
                if (customer == null)
                {
                    Inputter.redColor("\nNot found customer id!");
                }
            } while (customer == null);
            AccountList.ShowCustomerByID(customerID);
            do
            {
                Console.WriteLine("Input AccountID to begin");
                AccountID = Inputter.validateString($"\nAccount ID: ");
                account = AccountList.CheckAccountIDInCustomer(customer, AccountID);
                if (account == null)
                {
                    Inputter.redColor("\nNot found account id!");
                }
            } while (account == null);
            decimal money = Inputter.validateNumInt("Input money to Deposit: ");
            Transaction trans = new Transaction(DateTime.Now, money, "D", account);
            if (trans.Money > 0)
            {
                if (account.listTransaction == null)
                {
                    account.listTransaction = new List<Transaction>();
                }
                Inputter.greenColor("Deposit success!!!!");
                account.AddFunds(trans.Money);
                var tran = trans.TransactionID = listTransaction.Count() + 1;
                TransactionList.addToList(trans);
                account.listTransaction.Add(trans);
                displayTransaction(account);
            }
            else
            {
                Inputter.redColor("Withdraw fail!!!!");
            }
        }

    }


}
