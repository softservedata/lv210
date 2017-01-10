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
        private const double LeftBoundary = 10;
        private const double RightBoundary = 100;
        private const char Symbol = 'a';
        private const double Perimeter = 5;
        public static int LargestPerimeter(List<Shape> shapes)
        {
            int LargestShapeIndex = -1;
            double value = double.MinValue;

            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].Perimeter() > value)
                {
                    LargestShapeIndex = i;
                    value = shapes[i].Perimeter();
                }
            }
            return LargestShapeIndex + 1;
        }
        private static List<Shape> FindShapesWithAreaRange(List<Shape> shapes, double leftBoundary, double rightBoundary)
        {
            if (leftBoundary > rightBoundary)
            {
                throw new ArgumentException();
            }

            return shapes.Where(shape => (shape.Area() >= leftBoundary) && (shape.Area() <= rightBoundary)).ToList();
        }

        private static List<Shape> FindShapesWithAppropriateSymbol(List<Shape> shapes, char symbol)
        {
            return shapes.Where(shape => (shape.Name.Contains(symbol))).ToList();
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
            var ShapesWithAppropriateArea = FindShapesWithAreaRange(shapes, LeftBoundary, RightBoundary);
            WriteShapesToFile(ShapesWithAppropriateArea, "shapes with appropriate range");
        }

        public static void FindByNameAndWriteToFile(List<Shape> shapes)
        {
            var ShapesWithAppropriateSymbol = FindShapesWithAppropriateSymbol(shapes, Symbol);
            WriteShapesToFile(ShapesWithAppropriateSymbol, "shapes with name that contains symbol a");
        }
    }
}
