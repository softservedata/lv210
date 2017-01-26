using System;

namespace SimpleOperations
{
    public class Program
    {
        public static int ParseAtempt(string inputedData)
        {
            int readVariable;
            var parseAtempt = int.TryParse(inputedData, out readVariable);
            if (parseAtempt)
            {
                return readVariable;
            }
            else
            {
                throw new FormatException("Please, input <int> number");
            }
        }

        public static void Operations(int firstNumber, int secondNumber)
        {
            var mathObject = new MathOperations();
            var summ = mathObject.Add(firstNumber, secondNumber);
            var difference = mathObject.Subtract(firstNumber, secondNumber);
            var product = mathObject.Product(firstNumber, secondNumber);
            var fraction = mathObject.Divide(firstNumber, secondNumber);
            mathObject.PrintResults(summ, difference, product, fraction);
        }

        private static void Main()
        {
            Console.Write("Input two integer values divided by space: ");

            var firstNumber = ParseAtempt(Console.ReadLine());
            var secondNumber = ParseAtempt(Console.ReadLine());

            Operations(firstNumber, secondNumber);
            Console.ReadLine();
        }
    }
}
