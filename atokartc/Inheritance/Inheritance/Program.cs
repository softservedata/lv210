using System.Collections.Generic;

namespace Inheritance
{
    /// <summary>
    /// 1. Practical task:
    /// A) Create Console Application project.
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
    public class Program
    {
        public static void Main()
        {
            int shapesInList = 3;
            List<Shape> shapes = new List<Shape>();

            ManipulationWithShapes s = new ManipulationWithShapes();

            shapes = s.GetSpecificShapes(shapesInList);
            s.Print(shapes);

            Shape biggestShape = s.FindMaxPerimeter(shapes);

            shapes.Sort();
            s.Print(shapes);
        }
    }
}
