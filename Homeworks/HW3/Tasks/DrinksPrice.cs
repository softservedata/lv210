using System;

namespace DrinksPrice
{
    class Program
    {
        public enum Drinks { Coffee = 20, Tea = 10, Juice = 15, Water = 5 };
        static void Main(string[] args)
        {
            Console.WriteLine("Input name of the drink:");
            string drinkName = Console.ReadLine();
            if (Enum.IsDefined(typeof(Drinks), drinkName))
            {
                foreach (Drinks drink in Enum.GetValues(typeof(Drinks)))
                {
                    if (drink.ToString() == drinkName) Console.WriteLine("Drink name - {0}, drink price - {1}", drinkName, (int)drink);
                }
            }
            else
            {
                Console.WriteLine("Enter correct drink name");
            }
            Console.ReadLine();
        }
    }
}
