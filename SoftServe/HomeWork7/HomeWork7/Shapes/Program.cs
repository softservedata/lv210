using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Create Console Application project. 
    /// Create abstract class Shape with field name and property Name.
    /// Also add constructor with 1 parameter;
    /// and abstract methods Area() and Perimeter(), which can return area and perimeter of shape; 
    /// Create classes Circle, Square derived from Shape with field radius(for Circle) and side(for Square). 
    /// Add necessary constructors, properties to these clases, override methods from abstract class.
    /// 
    /// 1) In Main() create list of Shape, then ask user to enter data of 10 different shapes.
    /// Write name, area and perimeter all of shapes. 
    /// 2) Find shape with the largest perimeter and print its name.
    /// 3) Sort shapes by area and print obtained list(Remember about IComparable)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes = GetListOfShapes();

            shapes.ForEach(s => Console.WriteLine(s));

            shapes.Sort();

            Console.WriteLine("\nList after sort by area : ");

            shapes.ForEach(s => Console.WriteLine(s));

            var shapeNameWithLargestPerimetr = GetNameOfLargestShapePerimetr(shapes);

            Console.WriteLine("\nShape name with largest perimetr is : {0}", shapeNameWithLargestPerimetr);

            Console.ReadKey();
        }

        private static List<Shape> GetListOfShapes()
        {
            List<Shape> shapes = new List<Shape>();

            Console.Write("Input amount of shapes : ");
            var amountOfShapes = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfShapes; i++)
            {
                Console.WriteLine("Input type of shape \nCircle - 1 \nSquare - 2");
                var shapeType = int.Parse(Console.ReadLine());

                shapes.Add(DefineShapeType(shapeType));
            }

            return shapes;
        }

        /// <summary>
        /// Defines shape type - circle or square
        /// </summary>
        /// <param name="shapeType">Input type of shape</param>
        /// <returns></returns>
        private static Shape DefineShapeType(int shapeType)
        {
            Shape shape = null;
            string[] inputShapes;

            switch (shapeType)
            {
                case 1:
                    Console.WriteLine("Input data about circle : name and radius(divided by space)");
                    inputShapes = Console.ReadLine().Split(' ');
                    shape = new Circle(inputShapes[0], double.Parse(inputShapes[1]));
                    break;
                case 2:
                    Console.WriteLine("Input data about square : name and side length(divided by space)");
                    inputShapes = Console.ReadLine().Split(' ');
                    shape = new Square(inputShapes[0], double.Parse(inputShapes[1]));
                    break;
            }
            return shape;
        }

        /// <summary>
        /// Returns name of Shape with largest perimetr.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        private static string GetNameOfLargestShapePerimetr(List<Shape> shapes)
        {
            var largestPerimetr = 0.0;
            string shapeName = null;

            foreach (var item in shapes)
            {
                if (item.GetPerimetr() >= largestPerimetr)
                {
                    largestPerimetr = item.GetPerimetr();
                    shapeName = item.Name;
                }
            }

            return shapeName;
        }
    }
}
