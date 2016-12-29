using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>
            {
                new Circle("Circle 1", 5),
                new Circle("Circle 2", 6),
                new Circle("Circle 3", 7),
                new Circle("Circle 4", 8),
                new Circle("Circle 5", 9),
                new Square("Square 1", 5),
                new Square("Square 2", 6),
                new Square("Square 3", 7),
                new Square("Square 4", 8),
                new Square("Square 5", 9),
            };

            Console.WriteLine("---List of shapes---");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }

            Console.WriteLine("\n---Largest Perimetr---");
            Console.WriteLine(Shape.GetShapeWithLargestPerimeter(shapes));

            Console.WriteLine("\n---Sort shapes---");
            shapes.Sort();
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }


        }
    }
}
