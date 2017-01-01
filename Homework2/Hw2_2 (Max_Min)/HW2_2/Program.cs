using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read 3 integers and write max and min of them
            int a, b, c;
            Console.Write("Enter number 1: ");
            string s1 = (Console.ReadLine());
            a = Convert.ToInt32(s1);
            Console.Write("Enter number 2: ");
            string s2 =(Console.ReadLine());
            b = Convert.ToInt32(s2);
            Console.Write("Enter number 3: ");
            string s3 = (Console.ReadLine());
            c = Convert.ToInt32(s3);
            string answerMax = (a > b ? (a > c ? "Maximum is " + a : "Maximum is " + c) : (b > c ? "Maximum is " + b : "Maximum " + c));
            string answerMin = (a < b ? (a < c ? "Minimum is " + a : "Minimum is " + c) : (b < c ? "Minimum is " + b : "Minimum is " + c));
            Console.WriteLine();
            Console.WriteLine(answerMax);
            Console.WriteLine(answerMin);
            Console.ReadKey();
        }
    }
}
