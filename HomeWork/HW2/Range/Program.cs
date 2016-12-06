using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 float numbers: ");

            float num1 = float.Parse(Console.ReadLine());
            float num2 = float.Parse(Console.ReadLine());
            float num3 = float.Parse(Console.ReadLine());

            if (DoesBelong(num1))
                Console.WriteLine("First number belong to the range [-5,5]");
            else
                Console.WriteLine("First number does not belong to the range [-5,5]");

            if (DoesBelong(num2))
                Console.WriteLine("Second number belong to the range [-5,5]");
            else
                Console.WriteLine("Second number does not belong to the range [-5,5]");

            if (DoesBelong(num3))
                Console.WriteLine("Third number belong to the range [-5,5]");
            else
                Console.WriteLine("Third number does not belong to the range [-5,5]");

            Console.ReadKey();
        }

        public static bool DoesBelong(float a)
        {
            if (a >= -5 && a <= 5)
                return true;
            else
                return false;
        }

    }
}
