using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_1
{
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
            Console.WriteLine("Result \n");
            Console.WriteLine("a+b={0}", a + b);
            Console.WriteLine("a-b={0}", a - b);
            Console.WriteLine("a*b={0}", a * b);
            Console.WriteLine("a/b={0}", a / b);

        }
    }
}
