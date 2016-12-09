using System;

namespace SimpleOperations
{
    class Program
    {
        ///<summary>
        ///	Define integer variables a and b.
        ///	Read values a and b from Console and calculate: a+b, a-b, a*b, a/b. 
        ///	Output obtained results.
        ///</summary>
        public static int Summ(int FirstNumber, int SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
        public static int Difference(int FirstNumber, int SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }
        public static int Multiplax(int FirstNumber, int SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }
        public static int Division(int FirstNumber, int SecondNumber)
        {
            return FirstNumber / SecondNumber;
        }
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Input integer values");
            Console.Write("a = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b = ");
            b = Convert.ToInt32(Console.ReadLine());
            int sum, diff, mult, div;
            sum = Summ(a, b);
            diff = Difference(a, b);
            mult = Multiplax(a, b);
            div = Division(a, b);
            Console.WriteLine("a + b = {0};\na - b = {1};\na * b = {2};\na / b = {3};", sum, diff, mult, div);
            Console.ReadLine();
        }
    }
}
