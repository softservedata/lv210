using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFromConsole shapeFromConsole = new ShapeFromConsole();
            ShapeActions shapeActions = new ShapeActions();
            ShapeActionsInfo shapeActionsInfo = new ShapeActionsInfo();
            List<Shape> shapes = new List<Shape>();

            shapes = shapeFromConsole.GetListOfShapes();

            shapeActionsInfo.InfoAboutShapeAreaRange(shapes);

            shapeActionsInfo.ShapesWithAppropriateSymbol(shapes);

            Console.Write("\nInput perimetr for remove (if shape perimetr less than inputed) : ");
            var perimetr = int.Parse(Console.ReadLine());

            shapeActions.GetShapesWithPerimetrLessThan(shapes, perimetr);

            Console.WriteLine("After remove");
            shapes.ForEach(s => Console.WriteLine(s));

            Console.ReadKey();
        }
    }
}
