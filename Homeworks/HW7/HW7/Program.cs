using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var shapeOperations = new ShapeOperations();
            var shapesList = shapeOperations.CreateShapesList();

            shapeOperations.FindAndPrintShapeWithMaxPerimeter(shapesList);

            shapesList.Sort();
            shapeOperations.PrintShapes(shapesList);
        }
    }
}
