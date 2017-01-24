using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    /// <summary>
    /// Use classes Shape, Circle, Square from your previous homework.
    /// Use Linq and string functions to complete next tasks:
    /// 1) Create list of Shape and fill it with 6 different shapes(Circle and Square).
    /// 2) Find and write into the file shapes with area from range[10, 100]
    /// 3) Find and write into the file shapes which name contains letter 'a'
    /// 4) Find and remove from the list all shapes with perimeter less then 5. Write resulted list into Console
    /// </summary>
    public class Task1
    {
        public static void Main(string[] args)
        {
            Shape[] shapeArray = new Shape[]
            {
                new Circle("circle1", 10), new Circle("circle2", 2.5), new Circle("circle3", 15),
                new Square("square", 0.5), new Square("square2", 100.0), new Square("square3", 6)
            };

            List<Shape> shapes = new List<Shape>(shapeArray);
            double lowerBound = 10.0;
            double upperBound = 100.0;
            List<Shape> shapesInRange = ShapesOperations.GetShapesInRange(lowerBound, upperBound, shapes);
            FileOperations.WriteShapesListToFile("ShapesByArea.txt", shapesInRange);
            Console.WriteLine("Shapes with area in range [{0}, {1}]:", lowerBound, upperBound);
            ConsoleOperations.PrintShapes(shapesInRange);

            string letter = "a";
            List<Shape> shapesContainsLetter = ShapesOperations.GetShapesWithSubstring(letter, shapes);
            FileOperations.WriteShapesListToFile("ShapesByName.txt", shapesContainsLetter);
            Console.WriteLine("Shapes with '{0}' in name:", letter);
            ConsoleOperations.PrintShapes(shapesContainsLetter);

            double minimalPerimeter = 5.0;
            ShapesOperations.RemoveAllByPerimeter(shapes, minimalPerimeter);
            Console.WriteLine("Shapes with perimeter greater than {0}:", minimalPerimeter);
            ConsoleOperations.PrintShapes(shapes);
            Console.ReadKey();
        }
    }
}
