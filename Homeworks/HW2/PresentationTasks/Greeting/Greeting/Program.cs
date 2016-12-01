using System;

namespace Greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            int h, m;
            Console.WriteLine("Input hour");
            h = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input minutes");
            m = Convert.ToInt32(Console.ReadLine());
            if (h >= 6 && h < 12)
                Console.WriteLine("Good morning!");
            else if (h >= 12 && h < 18)
                Console.WriteLine("Good afternoon!");
            else if (h >= 18 && h < 22)
                Console.WriteLine("Good evening!");
            else Console.WriteLine("Good night!");
            Console.ReadLine();
        }
    }
}
