using System;

namespace AppropriateFunctions
{
    public class Functions
    {
        public static int max(int a, int b, int c)
        {
            return Math.Max(Math.Max(a, b), c);
        }

        public static int min(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }

        public static void FindMinMax()
        {
            Console.WriteLine("Enter three integer numbers:");

            var input_x1 = Console.ReadLine();
            var input_x2 = Console.ReadLine();
            var input_x3 = Console.ReadLine();

            int x1, x2, x3;

            var isInputX1Valid = int.TryParse(input_x1, out x1);
            var isInputX2Valid = int.TryParse(input_x2, out x2);
            var isInputX3Valid = int.TryParse(input_x3, out x3);

            if (isInputX1Valid && isInputX2Valid && isInputX3Valid)
            {
                Console.WriteLine("\nResults:");
                Console.WriteLine("Max - {0} ", max(x1, x2, x3));
                Console.WriteLine("Min - {0} ", min(x1, x2, x3));
            }
            else
            {
                Console.WriteLine("\nIncorrect value!\n");
            }

            Console.ReadLine();
           
        }
    }

}