using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pres2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number 1: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number 2: ");
            int b = Convert.ToInt32(Console.ReadLine());
            string answer = (a % 2 == 0)&&(b % 2 ==0)||(a % 2!=0)&&(b % 2 !=0)?"true":"false" ;
            string v = (answer == "true") ? "a and b have the same parity" : "a and b have different parity";
            Console.WriteLine(v);
            Console.ReadKey();
        }
    }
}
