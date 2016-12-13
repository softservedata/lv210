using System;
using System.Linq;

namespace HierarchyOfGeometricShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point[] p = { new Point(6, 2), new Point(2, 2), new Point(2, 6), new Point(6, 6) };
            Point[] p = { new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(6, 7) };
            //Point[] p = { new Point(10, 5), new Point(10, 5), new Point(10, 5), new Point(7, 8) };
            //Point[] p = { new Point(8, 2), new Point(11, 4), new Point(10, 10), new Point(2, 2), new Point(15, 8), new Point(5, 8), new Point(10, 5) };
            //Point[] p = { new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(8, 2) };
            var pol = new Rectangle(p);
            var validationsResults = pol.Validate();
            //pol.Area();

            if (validationsResults.Any())
            {
                foreach (var validationResult in validationsResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine(pol);
            }

            Console.ReadLine();
        }
    }
}
