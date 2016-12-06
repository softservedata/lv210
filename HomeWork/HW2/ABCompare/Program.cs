using System;


namespace ABCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;

            Console.WriteLine("Enter a and b");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            if (Math.Abs(a % 2) == Math.Abs(b % 2))
                Console.WriteLine("a and b are the same twoness");
            else
                Console.WriteLine("a and b are not the same twoness");

            Console.ReadKey();

        }

      
    }
}
