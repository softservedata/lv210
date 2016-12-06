using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeDivide3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer a and b");
            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine());

            if (a >= b)
                Console.WriteLine("Wrong data");
            Console.WriteLine("{0} numbers from a--b diapason", CountOf(a, b));

            Console.ReadLine();

        }

        static int CountOf(int a, int b)
        {
            int count = 0;
            for (int i = a; i <= b; i++)
                if (i % 3 == 0)
                    count++;
            return count;
        }
    }
}
