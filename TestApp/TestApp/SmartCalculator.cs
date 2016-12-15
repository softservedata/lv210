using System;


namespace TestApp
{
    public class SmartCalculator
    {
        public int FibonacciNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("You can't input number less than 1", "number");
            }
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                return FibonacciNumber(number - 2) + FibonacciNumber(number - 1);
            }
        }
        public int Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return Factorial(number - 1) * number;
            }
        }
        public double Pow(double x, int k)
        {
            if (k == 0)
            {
                return 1;
            }
            else
            {
                return Pow(x, k - 1) * x;
            }
        }
        public double MaxOfThreeNumbers(double a, double b, double c)
        {
            if (a > b && a > c)
            {
                return a;
            }
            if (b > a && b > c)
            {
                return b;
            }
            return c;
        }
        public bool IsNumberInRange(double digit, int low, int high)
        {
            if (digit >= low && digit <= high)
            {
                return true;
            }
            return false;
        }
    }
}
