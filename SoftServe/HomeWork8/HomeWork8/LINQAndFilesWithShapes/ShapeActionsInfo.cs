using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    class ShapeActionsInfo
    {
        private static readonly string pathToShapesFromRange = "ShapesFromRange.txt";
        private static readonly string pathToShapesWithAppropriateCharacter = "ShapeWithAppropriateCharacter.txt";
        ShapeActions shapeActions = new ShapeActions();

        /// <summary>
        /// Read values about range from console
        /// and call method FindAndWriteIntoFileShapesFromRange().
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        internal void InfoAboutShapeAreaRange(List<Shape> shapes)
        {
            Console.Write("Input lower boundary of range : ");
            var lowerBoundary = int.Parse(Console.ReadLine());

            Console.Write("Input upper boundary of range : ");
            var upperBoundary = int.Parse(Console.ReadLine());

            shapeActions.FindShapesFromRange(shapes, lowerBoundary, upperBoundary, pathToShapesFromRange);
        }

        /// <summary>
        /// Read character from console
        /// and call method ShapesWithAppropriateSymbol().
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        internal void ShapesWithAppropriateSymbol(List<Shape> shapes)
        {
            Console.Write("Input character for search : ");
            var appropriateChar = Console.ReadKey().KeyChar;

            shapeActions.FindShapesWithSymbol(shapes, appropriateChar, pathToShapesWithAppropriateCharacter);
        }
    }
}
