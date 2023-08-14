using Assignment.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    class Transaction
    {
        int transactionID;
        DateTime transactionDate;
        decimal money;
        String transactionType;
        Account account;

        public Transaction(DateTime transactionDate, decimal money, string transactionType, Account account) : this(transactionDate, money, transactionType)
        {
            this.account = account;
        }


        public DateTime TransactionDate { get => transactionDate; set => transactionDate = value; }
        public decimal Money { get => money; private set => money = value; }
        public string TransactionType { get => transactionType; set => transactionType = value; }
        public Account Account { get => account; set => account = value; }
        public int TransactionID { get => transactionID; set => transactionID = value; }

        public Transaction(int transactionID, DateTime transactionDate, decimal money, string transactionType)
        {
            this.TransactionID = transactionID;
            this.TransactionDate = transactionDate;
            this.Money = money;
            this.TransactionType = transactionType;
        }

        public Transaction(DateTime transactionDate, decimal money, string transactionType)
        {
            this.TransactionDate = transactionDate;
            this.Money = money;
            this.TransactionType = transactionType;
        }

        public Transaction()
        {
        }

        public Transaction(int transactionID, DateTime transactionDate, decimal money, string transactionType, Account account)
        {
            this.TransactionID = transactionID;
            this.TransactionDate = transactionDate;
            this.Money = money;
            this.TransactionType = transactionType;
            this.Account = account;
        }

        public Transaction InputTransaction(string msg, string type)
        {
            this.money = Inputter.validateNumInt(msg);
            this.TransactionDate = DateTime.Now;
            this.TransactionType = type;
            this.account = account;
            return this;
        }
        public override string? ToString() => $" + Transaction ID: {this.TransactionID}\t " +
                                          $"Amount: {this.Money}\t " +
                                          $"Date: {this.TransactionDate}\t " +
                                          $"Type: {this.transactionType}\t" +
                                          $"AccountID: {this.Account.AccountID}\n";
    }
}
