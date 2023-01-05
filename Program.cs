using System;

namespace FirstBankOfSuncoast
{

    class Transaction
    {
        public int Amount { get; set; }

        public string Type { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Account { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");
        }

        static void DisplayGreeting()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("    Welcome to First Bank of Suncoast    ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
