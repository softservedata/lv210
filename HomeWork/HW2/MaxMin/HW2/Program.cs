using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            Console.WriteLine("Enter 3 integer numbers: ");
            numbers[0] = int.Parse(Console.ReadLine());
            numbers[1] = int.Parse(Console.ReadLine());
            numbers[2] = int.Parse(Console.ReadLine());
            Console.WriteLine("The min number is: {0}; \nThe max number is: {1};", Methods.Min(numbers), Methods.Max(numbers));

            Console.ReadKey();
        }
    }
}
