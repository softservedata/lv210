using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTwo
{
    public class HW_2_5
    {
        /// <summary>
        /// Create Console Application project in VS.
        /// In method Main() write code for solving next task:
        /// read 3 integres and write max and min of them.
        /// </summary>
        ///             
        static int a = Convert.ToInt32(Console.ReadLine());
        static int b = Convert.ToInt32(Console.ReadLine());
        static int c = Convert.ToInt32(Console.ReadLine());

        public static void Main()
        {
            HW_2_5.Max(a, b, c);
            HW_2_5.Min(a, b, c);
        }


        public static void Max(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                Console.WriteLine("Max value is: {0}", a);
            }
            else if (b > c)
            {
                Console.WriteLine("Max value is: {0}", b);
            }
            else
            {
                Console.WriteLine("Max value is: {0}", c);
            }
        }
        public static void Min(int a, int b, int c)
        {
            if (a < b && a < c)
            {
                Console.WriteLine("Min value is: {0}", a);
            }
            else if (b < c)
            {
                Console.WriteLine("Min value is: {0}", b);
            }
            else
            {
                Console.WriteLine("Min value is: {0}", c);
            }
            Console.ReadKey();
        }
    }
}
