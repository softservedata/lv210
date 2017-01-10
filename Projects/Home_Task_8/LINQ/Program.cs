using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using System.IO;

namespace LINQ
{
    /// <summary>
    /// Use Linq and string functions to complete next tasks:
    /// 1) Create list of Shape and fill it with 6 different shapes(Circle and Square).
    /// 2) Find and write into the file shapes with area from range[10, 100]
    /// 3) Find and write into the file shapes which name contains letter 'a'
    /// 4) Find and remove from the list all shapes with perimeter less then 5. 
    /// Write resulted list into Console
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // --- Data Source ---

            List<Shape> shapes = new List<Shape>()
            {
                new Circle("Circle-1 (r = 0.5 cm)", 0.5),
                new Circle("Circle-2 (r = 3 cm)", 3),
                new Circle("Circle-3 (r = 6 cm)", 6),
                new Square("Square-1 (leg = 9 cm)", 9),
                new Square("Square-2 (leg = 12 cm)", 12),
                new Square("Square-3 (leg = 15 cm)", 15)
            };

            // --- Queries ---

            var areaInRangeQuery = shapes.Where(s => (s.Area >= Conditions.RangeLowerLimit) && (s.Area <= Conditions.RangeUpperLimit));
            var nameContainsCharA = shapes.Where(s => s.Name.ToLower().Contains(Conditions.DesireChar));
            
            // --- Query Execution ---

            areaInRangeQuery.WriteToFile("shapesLINQ.txt");
            nameContainsCharA.WriteToFile("shapesLINQ.txt");

            // --- Remove and display ---

            shapes.RemoveAll(p => p.Perimeter < Conditions.PerimeterLimit);
            Shape.ConsoleDisplay(shapes);
        }
    }

    static class ShapesUtilityClass
    {
        /// <summary>
        /// Extension method for writing shapes collection to file
        /// </summary>
        /// <param name="shapes">Shapes collection</param>
        /// <param name="fileName">File name or full file name</param>
        public static void WriteToFile(this IEnumerable<Shape> shapes, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                foreach (var shape in shapes)
                {
                    writer.WriteLine(shape.ToString());
                }
                writer.WriteLine($"Mod: {DateTime.Now} {Environment.NewLine}");
            }
        }
    }
}
