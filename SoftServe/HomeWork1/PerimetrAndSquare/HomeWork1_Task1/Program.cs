using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_Task1
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Input variable a : ");
            int a = int.Parse(Console.ReadLine());

            int area = SquareArea(a);

            int perimetr = SquarePerimetr(a);

            Console.WriteLine("Area of square is equal : {0}, perimeter is equal : {1} with length a : {2}", area, perimetr, a);

            Console.ReadKey();
        }

        public static int SquareArea(int a)
        {
            return a * a;
        }

        public static int SquarePerimetr(int a)
        {
            return 4 * a;
        }

        public static void CheckInputedData(int sideLength)
        {
            if (sideLength < 0)
            {
                throw new ArgumentException("Input data are negative.");
            }
        }
    }
}
