using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskWithShapes
{
    class Program
    {
        private const int Count = 3;
        private const double LeftBoundary = 10;
        private const double RightBoundary = 100;
        private const char Symbol = 'a';
        private const double PerimeterBoundary = 5;

        #region AllNessecaryFunctions

        public static int ParseIntData(string data)
        {
            int value;
            var isParsed = int.TryParse(data, out value);

            if (!isParsed)
            {
                throw new FormatException($"Can not convert <{data}> to <int>.");
            }

            return value;
        }

        public static double ParseDoubleData(string data)
        {
            double value;
            var isParsed = double.TryParse(data.Replace(".", ","), out value);

            if (!isParsed)
            {
                throw new FormatException($"Can not convert <{data}> to <double>.");
            }

            return value;
        }

        private static double GetValueFromConsole()
        {
            var readedData = Console.ReadLine();
            return ParseDoubleData(readedData);
        }

        private static void WriteMessagesInConsoleDueToChoise(int choise)
        {
            switch (choise)
            {
                case 1:
                {
                    Console.WriteLine("Creating circle...");
                    Console.Write("Radius = ");
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Creating square...");
                    Console.Write("Side = ");
                    break;
                }
                default:
                {
                    throw new ArgumentException("Such choise is impossible!");
                }
            }
        }

        private static Shape CreateAppropriateShape(int choise, double value)
        {
            Shape readedShape;

            switch (choise)
            {
                case 1:
                {
                    readedShape = new Circle(value);
                    break;
                }
                case 2:
                {
                    readedShape = new Square(value);
                    break;
                }
                default:
                {
                    throw new ArgumentException("Such choise is impossible!");
                }
            }

            return readedShape;
        }

        public static Shape ReadShape(int choise)
        {
            WriteMessagesInConsoleDueToChoise(choise);
            var value = GetValueFromConsole();

            return CreateAppropriateShape(choise, value);
        }

        public static int MakeChoise()
        {
            Console.WriteLine("\nCircle - press 1, square - press 2.");
            return ParseIntData(Console.ReadLine());
        }

        public static IList<Shape> ReadListOfShapes(int count)
        {
            var listOfShapes = new List<Shape>();

            Console.WriteLine($"Please, enter data about {count} shapes:");

            for (var i = 0; i < count; i++)
            {
                var choise = MakeChoise();
                var shape = ReadShape(choise);
                listOfShapes.Add(shape);
            }

            return listOfShapes;
        }

        public static void PrintListOfShapesToConsole(IList<Shape> listOfShapes)
        {
            foreach (var shape in listOfShapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }

        public static void WriteListToFile(IList<Shape> listOfShapes, string fileName)
        {
            var lines = listOfShapes.Select(shape => shape.ToString() + string.Empty);

            File.WriteAllLines(fileName, lines);
        }

        public static void FindByAreaAndWriteToFile(IList<Shape> listOfShapes)
        {
            var shapesWithAreaInRange = listOfShapes.FindAllWithAreaInRange(LeftBoundary, RightBoundary);
            WriteListToFile(shapesWithAreaInRange, $"shapes with area in [{LeftBoundary},{RightBoundary}]");
        }

        public static void FindByNameAndWriteToFile(IList<Shape> listOfShapes)
        {
            var shapesWithAppropriateSymbolInName = listOfShapes.FindAllWithAppropriateSymbolInName(Symbol);
            WriteListToFile(shapesWithAppropriateSymbolInName, $"shapes with name that contains symbol '{Symbol}'");
        }

        public static void FindByPerimeterAndWriteToConsole(IList<Shape> listOfShapes)
        {
            listOfShapes.RemoveAllWithPerimeterLessThanValue(PerimeterBoundary);
            Console.WriteLine($"\nRemoving shapes with perimeter less than {PerimeterBoundary}...");
            PrintListOfShapesToConsole(listOfShapes);
        }

        #endregion

        static void Main()
        {
            try
            {
                var listOfShapes = ReadListOfShapes(Count);
                FindByAreaAndWriteToFile(listOfShapes);
                FindByNameAndWriteToFile(listOfShapes);
                FindByPerimeterAndWriteToConsole(listOfShapes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }   
        }
    }
}
