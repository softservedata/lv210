using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1000000001;
            float f = i;
            i = (int)f;

            Console.WriteLine(i);

            #region 1st Taks
            Console.Write("Input variable a : ");
            int a = int.Parse(Console.ReadLine());

            int area = a * a;
            int perimetr = 4 * a;

            Console.WriteLine("Area : {0}, perimetr : {1} of squre with side length a : {2} ", area, perimetr, a);
            Console.WriteLine();
            #endregion

            #region 2nd Task
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("How old are you, {0}?",name);
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Hello, my name is {0}, I am {1} years old.", name, age);
            #endregion

            Console.ReadKey();
        }
    }
}
