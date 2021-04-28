using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    public class BankAccount
    {
        // Number represents Account Number. Defined as a String - can have letters in the account "number".
        public string Number { get; }
        public string Owner { get; set; }

        // Updated Balance to set balance to 0 and foreach new transaction at to the previous balance, then return the balance.
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        // Private, can only be accessed by the BankAccount Class
        private static int accountNumberSeed = 1234567890;

        // Created new List of Transactions
        private List<Transaction> allTransactions = new List<Transaction>();

        // Bank Account Object - Template for Bank Accounts
        public BankAccount(string name, decimal initialBalance)
        {
            // The Constructor - Initialize objects of the class BankAccount. "this" is not required.
            this.Owner = name;
            // Removed unnecessary initialBalance; Balance set to 0 on initialization of new account.

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            // Setting the BankAccount account Number to start at the seed and then increment for each new account number.
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            // Error Handling
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            // Error Handling
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        // Create an account history
        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            // HEADER
            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                // ROWS
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
