using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkPrice
{
    ////<sumarry>
    /// This program shows user the price of entered drink.
    ///</sumarry>
    
    class Program
    {
        public enum Drink { Coffee = 15, Tea = 8, Juice = 10, Water = 7 };
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the name of the drink:");

           var drinkName = Console.ReadLine();


            if (Enum.IsDefined(typeof(Drink),drinkName))
            {
                foreach (Drink current_drink in Enum.GetValues(typeof(Drink)))
                {
                    if (current_drink.ToString() == drinkName) Console.WriteLine("\nDrink name - {0}, drink price - {1} UAH.",drinkName,(int)current_drink);
                }
            }
            else
            {
                Console.WriteLine("\n Such drink does not exist!");
            }

            Console.ReadLine();
            
        }
    }
}
