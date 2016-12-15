using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartCalculator calculator = new SmartCalculator();
            int number = 0;

            // Entering data for Fibonacci method
            Console.WriteLine("Entering data for Fibonacci method");
            Console.Write("Enter which Fibonnacci number you want to see: ");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("{0} Fibonacci number is {1}", number, calculator.FibonacciNumber(number));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            Console.WriteLine();

            // Entering data for Factorial method
            Console.WriteLine("Entering data for Factorial method");
            Console.Write("Enter number for finding factorial: ");
            int numberFactorial = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Factorial of {0} is {1}", numberFactorial , calculator.Factorial(numberFactorial));
            Console.WriteLine();

            // Entering data for Pow method
            Console.WriteLine("Entering data for Pow method");
            Console.Write("Enter number for pow: ");
            double numberForPow = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter pow: ");
            int pow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} pow {1} is {2}", numberForPow, pow, calculator.Pow(numberForPow, pow));
            Console.WriteLine();

            // Entering data for MaxOfThreeNumbers method
            Console.WriteLine("Entering data for MaxOfThreeNumbers method");
            Console.Write("Enter number1: ");
            double number1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter number2: ");
            double number2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter number3: ");
            double number3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Maximum is {0}",calculator.MaxOfThreeNumbers(number1, number2, number3));
            Console.WriteLine();

            // Entering data for IsNumberInRange method
            Console.WriteLine("Entering data for IsNumberInRange method");
            Console.Write("Enter number: ");
            double numberForRange = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter lower boundary: ");
            int lowerBoundary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter upper boundary: ");
            int upperBoundary = Convert.ToInt32(Console.ReadLine());
            if(calculator.IsNumberInRange(numberForRange, lowerBoundary, upperBoundary))
                Console.WriteLine("Number {0} is in range [{1};{2}].", numberForRange, lowerBoundary, upperBoundary);
            else
                Console.WriteLine("Number {0} is not in range [{1};{2}].", numberForRange, lowerBoundary, upperBoundary);
            Console.ReadKey();
        }
    }
}
