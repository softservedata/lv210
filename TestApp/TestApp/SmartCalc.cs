using System;


namespace TestApp
{
    public class SmartCalc
    {
        public int fibonacciNumber(int number)
        {
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                return fibonacciNumber(number - 2) + fibonacciNumber(number - 1);
            }
        }
        public int factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return factorial(number - 1) * number;
            }
        }
        public double pow(double x, int k)
        {
            if (k == 0)
            {
                return 1;
            }
            else
            {
                return pow(x, k - 1) * x;
            }
        }
        public int maxOfThreeDigits(int a, int b, int c)
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
        public bool isDigitInRange(int digit, int low, int high)
        {
            if(digit>=low && digit<=high){
                return true;
            }
            return false;
        }
    }
}
