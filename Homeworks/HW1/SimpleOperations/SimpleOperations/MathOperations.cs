using System;

namespace SimpleOperations
{
    public class MathOperations
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public int Product(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public double Divide(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                return firstNumber / secondNumber;
            }
        }

        public void PrintResults(int summ, int difference, int product, double fraction)
        {
            Console.WriteLine("a + b = {0};\na - b = {1};\na * b = {2};\na / b = {3};", summ, difference, product, fraction);
        }
    }
}
