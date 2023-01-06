using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstBankOfSuncoast
{

    //create a Class for transactions
    class Transaction
    {
        public int Amount { get; set; }

        public string Type { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Account { get; set; }

    }


    class Program
    {

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);

            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);

            var userInput = Console.ReadLine();

            var userInputAsNumber = int.Parse(userInput);

            return userInputAsNumber;
        }

        //create a greeting for the app
        static void DisplayGreeting()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|  Welcome to First Bank of Suncoast    |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine();
            Console.WriteLine();
        }

        //create method to compute the bank balance

        static public int ComputeBalance(List<Transaction> transactionsForBalancing, string accountTypeToBalance)
        {
            var balanceFilteredTransactions = transactionsForBalancing.Where(transaction => transaction.Account == accountTypeToBalance);

            var balance = balanceFilteredTransactions.Where(transaction => transaction.Type == "Deposit").Sum(transaction => transaction.Amount) -
                          balanceFilteredTransactions.Where(transaction => transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

            return balance;
        }


        static void Main(string[] args)
        {
            DisplayGreeting();

            //create some dummy transactions

            var transactions = new List<Transaction>()
            {
                new Transaction { Type = "Deposit", Amount = 5000, Account = "Savings", TimeStamp = DateTime.Now },

                new Transaction { Type = "Deposit", Amount = 20000, Account = "Savings", TimeStamp = DateTime.Now},

                new Transaction { Type = "Deposit", Amount = 10000, Account = "Checking", TimeStamp = DateTime.Now },

                new Transaction { Type = "Withdraw", Amount = 250, Account = "Checking", TimeStamp = DateTime.Now },
            };
        }
    }
}


