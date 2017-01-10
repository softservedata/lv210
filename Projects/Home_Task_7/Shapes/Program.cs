using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Create abstract class Shape with field name and property Name. 
    /// Also add constructor with 1 parameter;
    /// and abstract methods Area() and Perimeter(), which can return area and perimeter of shape; 
    /// Create classes Circle, Square derived from Shape with field radius(for Circle) and side(for Square). 
    /// Add necessary constructors, properties to these clases, override methods from abstract class. 
    /// 1) In Main() create list of Shape, then ask user to enter data of 10 different shapes.
    /// Write name, area and perimeter all of shapes. 
    /// 2) Find shape with the largest perimeter and print its name.
    /// 3) Sort shapes by area and print obtained list(Remember about IComparable)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // --- Data Source ---
            List<Shape> shapes = new List<Shape>
            {
                new Circle("Circle (r=5)", 5),
                new Circle("Circle (r=6)", 6),
                new Circle("Circle (r=7)", 7),
                new Circle("Circle (r=8)", 8),
                new Circle("Circle (r=9)", 9),
                new Square("Square (leg=5)", 5),
                new Square("Square (leg=5)", 6),
                new Square("Square (leg=5)", 7),
                new Square("Square (leg=5)", 8),
                new Square("Square (leg=5)", 9),
            };

            Console.WriteLine("---List of shapes---");
            Shape.ConsoleDisplay(shapes);

            Console.WriteLine("\n---Largest Perimetr---");
            Console.WriteLine(Shape.GetShapeWithLargestPerimeter(shapes));

            Console.WriteLine("\n---Sort shapes---");
            shapes.Sort();
            Shape.ConsoleDisplay(shapes);
        }
    }
}
