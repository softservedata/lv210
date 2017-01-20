using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace LINQ
{
    public static class ShapesUtilityClass
    {
        public static void WriteToFile(this IEnumerable<Shape> shapes, string fileName, string title)
        {
            File.AppendAllText(fileName, $"{title}\r\n");
            foreach (var shape in shapes)
                File.AppendAllText(fileName, $"{shape}\r\n");
        }

        public static void DisplayOnConsole(IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
                Console.WriteLine(shape);
        }

        public static IList<Shape> GetAllWithAreaInRange(this IEnumerable<Shape> shapes, double lowerLimit, double upperLimit)
        {
            return shapes.Where(shape =>
            (shape.Area >= Conditions.RangeLowerLimit) &&
            (shape.Area <= Conditions.RangeUpperLimit)).ToList();
        }

        public static IList<Shape> GetAllWithProperCharInName(this IEnumerable<Shape> shapes, char desireChar)
        {
            return shapes.Where(shape =>
            shape.Name.ToLower().Contains(desireChar)).ToList();
        }

        public static void RemoveAllWithPerimeterLessThanLimit(this IList<Shape> shapes, double limit)
        {
            var shapesToRemove = shapes.Where(shape => shape.Perimeter < limit).ToList();
            foreach (var shape in shapesToRemove)
                shapes.Remove(shape);
        }
    }
}
