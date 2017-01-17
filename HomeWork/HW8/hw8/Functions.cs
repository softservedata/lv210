using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw8
{
    public class Functions
    {
        private const double leftBoundary = 10;
        private const double rightBoundary = 100;
        private const char symbol = 'a';
        private const double perimeter = 5;

        public static int LargestPerimeter(List<Shape> shapes)
        {
            int largestShapeIndex = -1;
            double value = double.MinValue;

            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].Perimeter() > value)
                {
                    largestShapeIndex = i;
                    value = shapes[i].Perimeter();
                }
            }
            return largestShapeIndex + 1;
        }

        public static List<Shape> FindShapesWithAreaRange(List<Shape> shapes, double leftBoundary, double rightBoundary)
        {
            if (leftBoundary > rightBoundary)
            {
                throw new ArgumentException();
            }

            return shapes.Where(shape => (shape.Area() >= leftBoundary) && (shape.Area() <= rightBoundary)).ToList();
        }

        public static List<Shape> FindShapesWithAppropriateSymbol(List<Shape> shapes, char symbol)
        {
            return shapes.Where(shape => (shape.name.Contains(symbol))).ToList();
        }

        public static void RemoveShapesWithPerimeterLessThanValue(ref List<Shape> shapes, double value)
        {
            shapes.RemoveAll(shape => (shape.Perimeter() < value));
        }

        public static void WriteShapesToFile(List<Shape> shapes, string fileName)
        {
            var lines = shapes.Select(shape => shape.ToString() + string.Empty);

            File.WriteAllLines(fileName, lines);
        }

        public static void WriteToFileWithAppropriateRange(List<Shape> shapes)
        {
            var shapesWithAppropriateArea = FindShapesWithAreaRange(shapes, leftBoundary, rightBoundary);
            WriteShapesToFile(shapesWithAppropriateArea, "shapes with appropriate range");
        }

        public static void FindByNameAndWriteToFile(List<Shape> shapes)
        {
            var shapesWithAppropriateSymbol = FindShapesWithAppropriateSymbol(shapes, symbol);
            WriteShapesToFile(shapesWithAppropriateSymbol, "shapes with name that contains symbol a");
        }
    }
}
