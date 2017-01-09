using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    class Program
    {
        private static readonly string pathToShapesFromRange = "ShapesFromRange.txt";
        private static readonly string pathToShapesWithAppropriateCharacter = "ShapeWithAppropriateCharacter.txt";

        /// <summary>
        /// Read values about range from console
        /// and call method FindAndWriteIntoFileShapesFromRange().
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        private static void ShapesFromRange(List<Shape> shapes)
        {
            Console.Write("Input lower boundary of range : ");
            var lowerBoundary = int.Parse(Console.ReadLine());

            Console.Write("Input upper boundary of range : ");
            var upperBoundary = int.Parse(Console.ReadLine());

            FindAndWriteIntoFileShapesFromRange(shapes, lowerBoundary, upperBoundary, pathToShapesFromRange);
        }

        /// <summary>
        /// Read character from console
        /// and call method ShapesWithAppropriateSymbol().
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        private static void ShapesWithAppropriateSymbol(List<Shape> shapes)
        {
            Console.Write("Input character for search : ");
            var appropriateChar = Console.ReadKey().KeyChar;

            FindAndWriteIntoFileShapesWithAppropriateSymbol(shapes, appropriateChar, pathToShapesWithAppropriateCharacter);
        }

        /// <summary>
        /// Read perimetr from console
        /// and remove from list shapes which perimeters are less than inputed.
        /// Write into console resulted list of shapes.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        private static void ShapesWithPerimetrLessThan(List<Shape> shapes)
        {
            Console.Write("\nInput perimetr for remove (if shape perimetr less than inputed) : ");
            var perimetr = int.Parse(Console.ReadLine());

            var shapesWithPerimetrLessThan = shapes.Where(i => i.GetPerimetr() < perimetr).ToList();

            shapesWithPerimetrLessThan.ForEach(i => shapes.Remove(i));

            Console.WriteLine("After remove");
            shapes.ForEach(s => Console.WriteLine(s));
        }

        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes = GetListOfShapes();

            ShapesFromRange(shapes);

            ShapesWithAppropriateSymbol(shapes);

            ShapesWithPerimetrLessThan(shapes);

            Console.ReadKey();
        }

        /// <summary>
        /// Input amount of shapes and create appropriate shape.
        /// </summary>
        /// <returns>Returns list of shapes</returns>
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

        /// <summary>
        /// Finds shapes which are in range from lowerBoundary to upperBoundary 
        /// and write them into file.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        /// <param name="lowerBoundary">Lower boundary for range</param>
        /// <param name="upperBoundary">Upper boundary for range</param>
        /// <param name="path">Path to file</param>
        private static void FindAndWriteIntoFileShapesFromRange(List<Shape> shapes, int lowerBoundary, int upperBoundary, string path)
        {
            var shapesFromRange = shapes.Where(i => (i.GetArea() >= lowerBoundary) && ((i.GetArea() <= upperBoundary))).ToList();

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in shapesFromRange)
                {
                    writer.WriteLine("Shape name : {0}, area : {1}, perimetr : {2}", item.Name, item.GetArea(), item.GetPerimetr());
                }
            }
        }

        /// <summary>
        /// Finds shapes which names contains appropriate character
        /// and write them into file.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        /// <param name="appropriateChar">Searched character</param>
        /// <param name="path">Path to file</param>
        private static void FindAndWriteIntoFileShapesWithAppropriateSymbol(List<Shape> shapes, char appropriateChar, string path)
        {
            var shapesWithAppropriateChar = shapes.Where(i => i.Name.Contains(appropriateChar.ToString().ToLower()) || i.Name.Contains(appropriateChar.ToString().ToUpper())).ToList();

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in shapesWithAppropriateChar)
                {
                    writer.WriteLine("Shape name : {0}, area : {1}, perimetr : {2}", item.Name, item.GetArea(), item.GetPerimetr());
                }
            }
        }
    }
}
