using System;
using System.Linq;

namespace Greeting
{
    public class Program
    {
        public static string GreetingChoise(int hour)
        {
            if (hour > 24 || hour < 1)
            {
                throw new FormatException("Hour should be in range of [1, 12]");
            }
            else if (hour >= 6 && hour < 12)
            {
               return "Good morning!";
            }
            else if (hour >= 12 && hour < 18)
            {
                return "Good afternoon!";
            }
            else if (hour >= 18 && hour < 22)
            {
                return "Good evening!";
            }
            else
            {
                return "Good night!";
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Input hour and minutes divided by space: ");
            int[] Variables;
            int ParsedValues;
            Variables = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select
                                                    (i => int.TryParse(i, out ParsedValues) ? ParsedValues : 0).ToArray();
            try
            {
                string greeting = GreetingChoise(Variables[0]);
                Console.WriteLine(greeting);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
