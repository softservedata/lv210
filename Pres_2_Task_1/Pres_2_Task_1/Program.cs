using System;

namespace Pres_2_Task_1
{
    class Program
    {
        enum Colors {Red, Blue, Green, Yellow };
        static void Main(string[] args)
        {
            Colors myColor = Colors.Red;
            Console.WriteLine("My favourite color is {0}.", myColor);
            Console.ReadKey();
    }
    }
}
 
