using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pres2_Task1_3
{
    class Program
    {
        static void Main(string[] args)
            {
            Console.Write("Enter hour: ");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter minutes: ");
            int m = Convert.ToInt32(Console.ReadLine());
            string dayPart = (h >= 6 && h < 12)?"Morning":(h >= 12 && h < 18) ? "Day" : (h >= 18 && h < 24) ? "Evening" : "Night";
            Console.WriteLine("Good {0}", dayPart);
            Console.ReadKey();
            }
    }
}
