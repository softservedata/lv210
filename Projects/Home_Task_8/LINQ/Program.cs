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
            // --- Data Source --- //

            List<Shape> shapes = ShapesUtilityClass.GetShapesCollection();

            // --- Queries --- //

            var areaInRange = shapes.Where(s => (s.Area >= Conditions.RangeLowerLimit) && (s.Area <= Conditions.RangeUpperLimit));
            var nameContainsCharA = shapes.Where(s => s.Name.ToLower().Contains(Conditions.DesireChar));

            // --- Query Execution --- //

            string fileName = "shapes.txt";

            areaInRange.WriteToFile(ShapesUtilityClass.GetPath(fileName));
            nameContainsCharA.WriteToFile(ShapesUtilityClass.GetPath(fileName));

            // --- Remove and display --- //

            shapes.RemoveAll(p => p.Perimeter < Conditions.PerimeterLimit);
            Shape.ConsoleDisplay(shapes);
        }
    }
}
