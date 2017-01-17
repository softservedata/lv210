using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    public class ShapeActions
    {
        /// <summary>
        /// Finds shapes which are in range from lowerBoundary to upperBoundary 
        /// and write them into file.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        /// <param name="lowerBoundary">Lower boundary for range</param>
        /// <param name="upperBoundary">Upper boundary for range</param>
        /// <param name="path">Path to file</param>
        internal void FindShapesFromRange(List<Shape> shapes, int lowerBoundary, int upperBoundary, string path)
        {
            var shapesFromRange = shapes.Where(i => (i.GetArea() >= lowerBoundary) && ((i.GetArea() <= upperBoundary))).ToList();

            WriteListOfShapesIntoFile(shapesFromRange, path);
        }

        /// <summary>
        /// Finds shapes which names contains appropriate character
        /// and write them into file.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        /// <param name="appropriateChar">Searched character</param>
        /// <param name="path">Path to file</param>
        internal void FindShapesWithSymbol(List<Shape> shapes, char appropriateChar, string path)
        {
            var shapesWithAppropriateChar = shapes.Where(i => i.Name.Contains(appropriateChar.ToString().ToLower()) || i.Name.Contains(appropriateChar.ToString().ToUpper())).ToList();

            WriteListOfShapesIntoFile(shapesWithAppropriateChar, path);
        }

        /// <summary>
        /// Read perimetr from console
        /// and remove from list shapes which perimeters are less than inputed.
        /// Write into console resulted list of shapes.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        public List<Shape> GetShapesWithPerimetrLessThan(List<Shape> shapes, double perimetr)
        {
            var shapesWithPerimetrLessThan = shapes.Where(i => i.GetPerimetr() < perimetr).ToList();

            shapesWithPerimetrLessThan.ForEach(i => shapes.Remove(i));

            return shapesWithPerimetrLessThan;
        }

        private void WriteListOfShapesIntoFile(List<Shape> shapes, string path)
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
