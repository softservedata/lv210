using System;

namespace Pres2_Task1
{
    public class Program
    {
        public static string ParityVerifying( double number1, double number2)
        { 
            return (number1 % 2 == 0) && (number2 % 2 == 0) || (number1 % 2 != 0) && (number2 % 2 != 0) ? "true" : "false";
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number 1: ");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number 2: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            string answer = ParityVerifying(number1, number2);
            string conclusion = (answer == "true") ? "a and b have the same parity" : "a and b have different parity";
            Console.WriteLine(conclusion);
            Console.ReadKey();
        }
    }
}
