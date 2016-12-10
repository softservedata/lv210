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
        static void Main(string[] args)
        {
            Console.Write("Input two integer values divided by space: ");

            int[] Variables;
            int ParsedValues;
            Variables = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select
                                                    (i => int.TryParse(i, out ParsedValues) ? ParsedValues : 0).ToArray();
            int summ, difference, product, fraction;
            MathOperations MathObject = new MathOperations();

            summ =  MathObject.Add(Variables[0], Variables[1]);
            difference = MathObject.Subtract(Variables[0], Variables[1]);
            product = MathObject.Product(Variables[0], Variables[1]);
            fraction = MathObject.Division(Variables[0], Variables[1]);

            Console.WriteLine("a + b = {0};\na - b = {1};\na * b = {2};\na / b = {3};", summ, difference, product, fraction);
            Console.ReadLine();
        }
    }
}
