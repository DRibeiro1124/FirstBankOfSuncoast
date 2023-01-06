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

            var userHasChosenToQuit = false;
            while (userHasChosenToQuit == false)
            {
                Console.WriteLine("Your Banking Menu Options:");
                Console.WriteLine();
                Console.WriteLine("(D)eposit");
                Console.WriteLine("(W)ithdraw");
                Console.WriteLine("(T)ransfer");
                Console.WriteLine("(B)alance");
                Console.WriteLine("(H)istory");
                Console.WriteLine("(Q)uit");

                var choice = PromptForString("Choice: ").ToUpper().Trim();
                switch (choice)
                {
                    case "D":
                        var depositChoice = PromptForString("Sorry, unable to deposit cash at this moment. Please make another selection");
                        break;

                    case "W":
                        var withdrawChoice = PromptForString("Do you want withdraw from Savings or Checking? ");

                        var withdrawMaximum = ComputeBalance(transactions, withdrawChoice);

                        var withdrawAmount = PromptForInteger($"How much do you want to withdraw from {withdrawChoice} -- up to {withdrawMaximum}? ");

                        if (withdrawAmount > withdrawMaximum)
                        {
                            Console.WriteLine("No funds!");
                        }
                        else
                        {
                            var transaction = new Transaction()
                            {
                                Account = withdrawChoice,
                                Amount = withdrawAmount,
                                Type = "W",
                                TimeStamp = DateTime.Now,
                            };

                            transactions.Add(transaction);
                        }
                        break;

                    case "T":
                        break;

                    case "B":
                        var balanceChoice = PromptForString("Do you want balance for Savings or Checking? ");

                        var balance = ComputeBalance(transactions, balanceChoice);

                        Console.WriteLine($"Your {balanceChoice} balance is {balance}");
                        break;

                    case "H":
                        var historyChoice = PromptForString("Do you want history for Savings or Checking? ");

                        var filteredTransactions = transactions.Where(transaction => transaction.Account == historyChoice);

                        foreach (var transaction in filteredTransactions)
                        {
                            Console.WriteLine($"{transaction.Amount} - {transaction.Type}");
                        }

                        break;

                    case "Q":
                        userHasChosenToQuit = true;
                        break;
                }
            }
        }
    }
}

