using System;
using System.Linq;

namespace SimpleOperations
{
    class Program
    {
        ///<summary>
        ///	Define integer variables a and b.
        ///	Read values a and b from Console and calculate: a+b, a-b, a*b, a/b. 
        ///	Output obtained results.
        ///</summary>
        public static void Operations(int FirstNumber, int SecondNumber)
        {
            MathOperations MathObject = new MathOperations();
            int summ = MathObject.Add(FirstNumber, SecondNumber);
            int difference = MathObject.Subtract(FirstNumber, SecondNumber);
            int product = MathObject.Product(FirstNumber, SecondNumber);
            int fraction = MathObject.Division(FirstNumber, SecondNumber);
            Console.WriteLine("a + b = {0};\na - b = {1};\na * b = {2};\na / b = {3};", summ, difference, product, fraction);
        }

        static void Main(string[] args)
        {
            Console.Write("Input two integer values divided by space: ");

            int[] Variables;
            int ParsedValues;
            Variables = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select
                                                    (i => int.TryParse(i, out ParsedValues) ? ParsedValues : 0).ToArray();

            Operations(Variables[0], Variables[0]);
            Console.ReadLine();
        }
    }
}
