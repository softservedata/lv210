using System;
using System.Collections.Generic;

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
        enum ShapeType
        {
            Circle = 1,
            Square
        }

        static void Main(string[] args)
        {
            ShapeFromConsole shapeFromConsole = new ShapeFromConsole();
            List<Shape> shapes = new List<Shape>();

            shapes = shapeFromConsole.GetListOfShapes();

            shapes.ForEach(s => Console.WriteLine(s));

            shapes.Sort();

            Console.WriteLine("\nList after sort by area : ");

            shapes.ForEach(s => Console.WriteLine(s));

            var shapeNameWithLargestPerimetr = GetShapeNameWithLargestPerimetr(shapes);

            Console.WriteLine("\nShape name with largest perimetr is : {0}", shapeNameWithLargestPerimetr);

            Console.ReadKey();
        }

        //private static List<Shape> GetListOfShapes()
        //{
        //    List<Shape> shapes = new List<Shape>();

        //    Console.Write("Input amount of shapes : ");
        //    var amountOfShapes = int.Parse(Console.ReadLine());

        //    for (int i = 0; i < amountOfShapes; i++)
        //    {
        //        Console.WriteLine("Input type of shape \nCircle - 1 \nSquare - 2");
        //        var shapeType = int.Parse(Console.ReadLine());

        //        shapes.Add(DefineShapeType((ShapeType)shapeType));
        //    }

        //    return shapes;
        //}

        /// <summary>
        /// Defines shape type - circle or square
        /// </summary>
        /// <param name="shapeType">Input type of shape</param>
        /// <returns></returns>
        //private static Shape DefineShapeType(ShapeType shapeType)
        //{
        //    Shape shape = null;
        //    string shapeName = string.Empty;
        //    double shapeLength = 0.0;

        //    switch ((int)shapeType)
        //    {
        //        case 1:
        //            //Console.WriteLine("Input data about circle : name and radius(divided by space)");
        //            //inputShapes = Console.ReadLine().Split(' ');
        //            //while (double.Parse(inputShapes[1]) <= 0)
        //            //{
        //            //    Console.WriteLine("Incorrect data (length should be bigger than 0). Please try again : ");
        //            //    inputShapes = Console.ReadLine().Split(' ');
        //            //}
        //            GetCorrectValuesForShape(out shapeName, out shapeLength);
        //            shape = new Circle(shapeName, shapeLength);
        //            break;
        //        case 2:
        //            //Console.WriteLine("Input data about square : name and side length(divided by space)");
        //            //inputShapes = Console.ReadLine().Split(' ');
        //            //while (double.Parse(inputShapes[1]) <= 0)
        //            //{
        //            //    Console.WriteLine("Incorrect data (length should be bigger than 0). Please try again : ");
        //            //    inputShapes = Console.ReadLine().Split(' ');
        //            //}
        //            GetCorrectValuesForShape(out shapeName, out shapeLength);
        //            shape = new Square(shapeName, shapeLength);
        //            break;
        //    }

        //    return shape;
        //}

        /// <summary>
        /// Returns name of Shape with largest perimetr.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        private static string GetShapeNameWithLargestPerimetr(List<Shape> shapes)
        {
            var largestPerimetr = 0.0;
            string shapeName = string.Empty;

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

        //private static void GetCorrectValuesForShape(out string shapeName, out double length)
        //{
        //    string[] inputShapes;

        //    Console.WriteLine("Input data about circle : name and radius(divided by space)");
        //    inputShapes = Console.ReadLine().Split(' ');
        //    while (double.Parse(inputShapes[1]) <= 0)
        //    {
        //        Console.WriteLine("Incorrect data (length should be bigger than 0). Please try again : ");
        //        inputShapes = Console.ReadLine().Split(' ');
        //    }

        //    shapeName = inputShapes[0];
        //    length = double.Parse(inputShapes[1]);
        //}
    }
}
