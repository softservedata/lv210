using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    public static class ShapeActions
    {
        /// <summary>
        /// Finds shapes which are in range from lowerBoundary to upperBoundary.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        /// <param name="lowerBoundary">Lower boundary for range</param>
        /// <param name="upperBoundary">Upper boundary for range</param>
        public static IEnumerable<Shape> FindShapesFromRange(this IEnumerable<Shape> shapes, double lowerBoundary, double upperBoundary)
        {
            return shapes.Where(x => ShapesInRange(x, lowerBoundary, upperBoundary));
        }

        private static bool ShapesInRange(Shape shape, double lowerBoundary, double upperBoundary)
        {
            var area = shape.GetArea();
            return ((area >= lowerBoundary) && (area <= upperBoundary));
        }

        /// <summary>
        /// Finds shapes which names contains appropriate character.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        /// <param name="appropriateChar">Searched character</param>
        public static IEnumerable<Shape> FindShapesWithSymbol(this IEnumerable<Shape> shapes, char appropriateChar)
        {
            return shapes.Where(x => x.Name.Contains(appropriateChar));

            //WriteListOfShapesIntoFile(shapesWithAppropriateChar, path);
        }

        /// <summary>
        /// Remove from list shapes which perimeters are less than inputed.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        /// <param name="perimetr">Input perimetr</param>
        public static void RemoveShapesWithPerimetrLessThanValue(this List<Shape> shapes, double perimetr)
        {
            var shapesToRemove = shapes.Where(i => i.GetPerimetr() < perimetr).ToList();

            foreach (var shape in shapesToRemove)
            {
                shapes.Remove(shape);
            }
        }

        public static void WriteListOfShapesIntoFile(this IEnumerable<Shape> shapes, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in shapes)
                {
                    writer.WriteLine("Shape name : {0}, area : {1}, perimetr : {2}", item.Name, item.GetArea(), item.GetPerimetr());
                }
            }
        }
    }
}
