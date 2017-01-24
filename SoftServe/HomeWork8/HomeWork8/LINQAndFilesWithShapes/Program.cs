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
        private const string pathToShapesFromRange = "ShapesFromRange.txt";
        private const string pathToShapesWithAppropriateCharacter = "ShapeWithAppropriateCharacter.txt";
        private const char APPROPRIATE_CHAR = 'C';
        private const double LOWER_BOUNDARY = 10;
        private const double UPPER_BOUNDARY = 100;
        private const double PERIMETR = 10;

        static void Main(string[] args)
        {
            IEnumerable<Shape> shapes = new List<Shape>()
            {
                new Circle(1), new Circle(3), new Circle(5),
                new Square(2), new Square(5), new Square(10)
            };

            shapes.FindShapesFromRange(LOWER_BOUNDARY, UPPER_BOUNDARY).WriteListOfShapesIntoFile(pathToShapesFromRange);

            shapes.FindShapesWithSymbol(APPROPRIATE_CHAR).WriteListOfShapesIntoFile(pathToShapesWithAppropriateCharacter);

            shapes.ToList().RemoveShapesWithPerimetrLessThanValue(PERIMETR);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }

            Console.ReadKey();
        }
    }
}
