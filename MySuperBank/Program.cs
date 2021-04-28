using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Hardcoded new Object
            var account = new BankAccount("Kendra", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

            // Hardcode a Withdrawls as a Test. Extra Console.WriteLines unnecessary after creation of GetAccountHistory method.
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            //Console.WriteLine(account.Balance);
            account.MakeWithdrawal(120, DateTime.Now, "Hammock");
            //Console.WriteLine(account.Balance);

            // Hardcode Deposit as a Test
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            //Console.WriteLine(account.Balance);

            // Added Report for Account History
            Console.WriteLine(account.GetAccountHistory());

            ////Test that the initial balances must be positive.
            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}

            ////Test for a negative balance.
            //try
            //    {
            //        account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            //    }
            //    catch (InvalidOperationException e)
            //    {
            //        Console.WriteLine("Exception caught trying to overdraw");
            //        Console.WriteLine(e.ToString());
            //    }
        }
    }
}
