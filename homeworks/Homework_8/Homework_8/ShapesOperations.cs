using System.Collections.Generic;
using System.Linq;

namespace Homework_8
{
    public class ShapesOperations
    {
        public static List<Shape> GetShapesInRange(double lowerBound, double upperBound, List<Shape> shapes)
        {
            var shapesInRange = shapes.Where(item => item.Area() >= lowerBound && item.Area() <= upperBound);
            return shapesInRange.ToList();
        }

        public static List<Shape> GetShapesWithSubstring(string substring, List<Shape> shapes)
        {
            var shapesContainsLetter = shapes.Where(item => item.Name.Contains(substring));
            return shapesContainsLetter.ToList();
        }
        
        public static void RemoveAllByPerimeter(List<Shape> shapes, double minimalPerimeter)
        {
            shapes.RemoveAll(item => item.Perimeter() < minimalPerimeter);
        }
    }
}
