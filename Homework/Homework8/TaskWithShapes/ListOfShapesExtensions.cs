using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskWithShapes
{
    public static class ListOfShapesExtensions
    {
        public static IList<Shape> FindAllWithAreaInRange(this IList<Shape> listOfShapes, double leftBoundary,
            double rightBoundary)
        {
            if (listOfShapes == null)
            {
                throw new ArgumentNullException($"IList<Shape> is null!");
            }

            if (leftBoundary >= rightBoundary)
            {
                throw new ArgumentException("Incorrect boundaries!");
            }

            return listOfShapes.Where(shape => (shape.Area() >= leftBoundary) &&
                                               (shape.Area() <= rightBoundary)).ToList();
        }

        public static IList<Shape> FindAllWithAppropriateSymbolInName(this IList<Shape> listOfShapes, char symbol)
        {
            if (listOfShapes == null)
            {
                throw new ArgumentNullException($"IList<Shape> is null!");
            }

            var queryResult = from shape in listOfShapes where shape.Name.Contains(symbol) select shape;

            return queryResult.ToList();
        }

        public static void FindAndRemoveAllWithPerimeterLessThanValue(this IList<Shape> listOfShapes, double value)
        {
            if (listOfShapes == null)
            {
                throw new ArgumentNullException($"IList<Shape> is null!");
            }

            if (value <= 0)
            {
                throw new ArgumentException("Perimeter value can not be less or equal zero!");
            }

            var itemsToRemove = listOfShapes.Where(shape => (shape.Perimeter() < value)).ToList();
            foreach (var itemToRemove in itemsToRemove)
            {
                listOfShapes.Remove(itemToRemove);
            }
        }
    }
}