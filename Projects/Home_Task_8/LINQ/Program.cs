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
            // 1. Create list of Shape and fill it with 6 different shapes(Circle and Square).

            IList<Shape> shapes = new List<Shape>()
            {
                new Circle(0.5), new Circle(3), new Circle(6),
                new Square(9), new Square(12), new Square( 15)
            };

            // 2. Find and write into the file shapes with area from range[10, 100]

            string fileName = "shapes.txt";
            shapes.GetAllWithAreaInRange(Conditions.RangeLowerLimit, Conditions.RangeUpperLimit)
                .WriteToFile(fileName, title: "Shapes with area from range[10, 100]");

            // 3. Find and write into the file shapes which name contains letter 'a'

            shapes.GetAllWithProperCharInName(Conditions.DesireChar)
                .WriteToFile(fileName, title: "Shapes which name contains letter 'a'");

            // 4. Find and remove from the list all shapes with perimeter less then 5. Write resulted list into Console

            shapes.RemoveAllWithPerimeterLessThanLimit(Conditions.PerimeterLimit);
            shapes.DisplayOnConsole();
        }
    }
}
