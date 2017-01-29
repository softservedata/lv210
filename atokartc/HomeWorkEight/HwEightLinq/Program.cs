using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HwEightLinq
{
    /// <summary>
    /// A) Create Console Application project.
    /// Use classes Shape, Circle, Square from your previous homework.
    /// Use Linq and string functions to complete next tasks:
    /// 1) Create list of Shape and fill it with 6 different shapes(Circle and Square).
    /// 2) Find and write into the file shapes with area from range[10, 100]
    /// 3) Find and write into the file shapes which name contains letter 'a'
    /// 4) Find and remove from the list all shapes with perimeter less then 5. Write resulted list into Console
    /// </summary>
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
                new Circle("circleOne", 10), new Circle("circleTwo", 2.5), new Circle("circleThree", 15),
                new Square("squareOne", 5), new Square("squareTwo", 1.0), new Square("squareThree", 6)
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
