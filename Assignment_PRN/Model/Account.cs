using Assignment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    class Account
    {
        String accountID;
        decimal remainder;
        TransactionList transactions;
        Customer customer;
        public List<Transaction> listTransaction { get; set; }
        public string AccountID { get => accountID; set => accountID = value; }
        public decimal Remainder { get => remainder; private set => remainder = value; }
        public TransactionList Transactions { get => transactions; set => transactions = value; }
        public Customer Customer { get => customer; set => customer = value; }

        public Account()
        {
            listTransaction = new List<Transaction>();
        }

        public override string? ToString() => $"+ Account ID: {this.AccountID}; " +
                                         $"Balance: {this.remainder}; " /*+*/
                                         /*$"Num of transactions: {transactionManager.Transactions.Count()}\n"*/;

        public Account(string accountID, decimal remainder, TransactionList transactions, Customer customer)
        {
            this.accountID = accountID;
            this.remainder = remainder;
            this.transactions = transactions;
            this.customer = customer;
        }

        public Account(string accountID, decimal remainder)
        {
            this.accountID = accountID;
            this.remainder = remainder;
        }

        public Account(string accountID, decimal remainder, Customer customer)
        {
            this.accountID = accountID;
            this.remainder = remainder;
            this.customer = customer;
        }

        public Account(string accountID, decimal remainder, TransactionList transactions, Customer customer, List<Transaction> listTransaction) : this(accountID, remainder, transactions, customer)
        {
            this.listTransaction = listTransaction;
        }

        public Account(string accountID, decimal remainder, Customer customer, List<Transaction> listTransaction) : this(accountID, remainder, customer)
        {
            this.listTransaction = listTransaction;
        }

        public Account(string accountID, List<Transaction> listTransaction)
        {
            this.accountID = accountID;
            this.listTransaction = listTransaction;
        }

        public Account(List<Transaction> listTransaction)
        {
            this.listTransaction = listTransaction;
        }

        public bool AddFunds(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount");
                return false;
            }
            else
            {
                remainder += amount;
            }
            return true;
        }
        public void MakePurchase(Customer customer, decimal amount)
        {
            if (CanAfford(amount))
            {
                remainder -= amount;
            }
            else
            {
                Console.WriteLine("Not valid.Please try again");
            }
        }
        public bool CanAfford(decimal amount)
        {
            return amount <= remainder;
        }
    }
}

