using System;

namespace AppropriateFunctions
{
    public class Functions
    {
        public static bool IsMultiplyOfThree(int number)
        {
            return number % 3 == 0;
        }

        public static int CountOfNumbersMultiplyOfThree(int a, int b)
        {
            int count = 0;
            int number = a;

            while (number <= b)
            {
                if (IsMultiplyOfThree(number)) count++;
                number++;
            }

            return count;
        }

        public static void InputsAndResults()
        {
            Console.WriteLine("Please, enter interval [a,b] for searching:");

            Console.Write("\na = ");
            var input_a = Console.ReadLine();

            Console.Write("b = ");
            var input_b = Console.ReadLine();

            int a, b;

            var isInputAValid = int.TryParse(input_a, out a);
            var isInputBValid = int.TryParse(input_b, out b);

            if (isInputAValid && isInputBValid)
            {
                Console.WriteLine("\nCount of numbers multiple of three on the interval [{0},{1}] is {2}.", a, b, CountOfNumbersMultiplyOfThree(a, b));
            }
            else
            {
                Console.WriteLine("\nIncorrect value!\n");
            }

            Console.ReadLine();
        }
    }
}