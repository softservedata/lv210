using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class Program
    {
        public static void WriteListToFile(string pathToFile, List<Shape> list)
        {
            File.WriteAllLines(pathToFile, list.Select(item => item.ToString()));
        }

        static void Main(string[] args)
        {
            Shape[] shapeArray = new Shape[]
            {
                new Circle("circle1", 10), new Circle("circle2", 2.5), new Circle("circle3", 15),
                new Square("square", 5), new Square("square2", 1.0), new Square("square3", 6)
            };

            List<Shape> shapes = new List<Shape>(shapeArray);
            int lowerBound = 10;
            int upperBound = 100;
            var shapesInRange = shapes.Where(item => item.Area() >= lowerBound && item.Area() <= upperBound);
            WriteListToFile("ShapesByArea.txt", shapesInRange.ToList());

            string letter = "a";
            var shapesContainsLetter = shapes.Where(item => item.Name.Contains(letter));
            WriteListToFile("ShapesByName.txt", shapesContainsLetter.ToList());

            int minimalPerimeter = 5;
            shapes.RemoveAll(item => item.Perimeter() < minimalPerimeter);
            shapes.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
