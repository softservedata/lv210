using System;
using System.Collections;
using System.Collections.Generic;

namespace HW7
{
    public class ShapeOperations
    {
        public static int ParseAtempt(string inputedData)
        {
            int readVariable;
            var parseAtempt = int.TryParse(inputedData, out readVariable);
            if (parseAtempt && readVariable > 0)
            {
                return readVariable;
            }
            else
            {
                throw new FormatException("Please, input positive <double> number");
            }
        }

        public List<Shape> CreateShapesList()
        {
            var shapesList = new List<Shape>();

            Console.Write("How many shapes you want to work with? ");
            var shapesCount = ParseAtempt(Console.ReadLine());

            Console.WriteLine("Add shapes to list");
            Console.WriteLine("Print 1 to add circle, print 2 to add square");

            Shape shape = null;

            for (int i = 0; i < shapesCount; i++)
            {
                switch (ParseAtempt(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Input circle radius: ");
                        var radius = ParseAtempt(Console.ReadLine());
                        shape = new Circle(radius);
                        break;
                    case 2:
                        Console.Write("Input square side: ");
                        var side = ParseAtempt(Console.ReadLine());
                        shape = new Square(side);
                        break;
                }

                shapesList.Add(shape);
            }
            return shapesList;
        }

        public void FindAndPrintShapeWithMaxPerimeter(List<Shape> shapeList)
        {
            var maxShape = shapeList[0];

            foreach (var item in shapeList)
            {
                if (item.Perimeter() > maxShape.Perimeter())
                {
                    maxShape = item;
                }
            }
            Console.Write("Shape with biggest perimeter:");
            Console.WriteLine(maxShape.ToString());
        }

        //
        public void PrintShapes(IEnumerable dataToPrint)
        {
            Console.WriteLine("Shape list:");
            foreach (var item in dataToPrint)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

    }
}
