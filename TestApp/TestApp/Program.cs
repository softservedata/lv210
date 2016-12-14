using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SmartCalc calculator = new SmartCalc();

            Console.WriteLine("10 fibonacci number is "+calculator.fibonacciNumber(10));
            Console.ReadKey();
            Console.WriteLine("4 factorial is " + calculator.factorial(4));
            Console.ReadKey();
            Console.WriteLine("2 pow 5 is " + calculator.pow(2,5));
            Console.ReadKey();
            Console.WriteLine("max digit is " + calculator.maxOfThreeDigits(3,10,8));
            Console.ReadKey();
            Console.WriteLine("Digit in range. It is " + calculator.isDigitInRange(5,2,10));
            Console.ReadKey();
        }
    }
}
