using System;

namespace Square
{
    class Program
    {
	/*
		define integer variable a.
		Read the value of a from console and calculate area and perimetr of square with length a. 
		Output obtained results.
	*/
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Input length");
            a = Convert.ToInt32(Console.ReadLine());
            int perimetr = a * 4;
            int area = a * a;
            Console.WriteLine("Perimetr = {0};\nArea = {1};", perimetr, area);
            Console.ReadLine();
        }
    }
}
