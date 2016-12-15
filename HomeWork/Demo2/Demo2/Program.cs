using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dot dot1 = new Dot(1, 1);
            Dot dot2 = new Dot(5, 1);
            Dot dot3 = new Dot(2.5, 8);
            Dot dot4 = new Dot(2.5, 3);
            Triangle triangle = new Triangle(dot1, dot2, dot3);
            triangle.GetInfo();
            if (triangle.DoesContainDot(dot4))
            {
                Console.WriteLine("Dot {0} belongs to triangle", dot4.Show());
            }
            
            Console.ReadKey();
        }
    }
}
