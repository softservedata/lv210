using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_1
{
    /// <summary>
    /// Define integer variables a and b.
    /// Read values a and b from Console and calculate: a+b, a-b, a*b, a/b. 
    /// Output obtained results.
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            //Read Variables
            Console.Write("Enter a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = Int32.Parse(Console.ReadLine());

            //Result
            Console.WriteLine("\n-----Result------");
            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            Console.WriteLine("a / b = {0}", a / b);

        }
    }
}
