using System;

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


        static void Main(string[] args)
        {
            DisplayGreeting();
        }
    }
}


