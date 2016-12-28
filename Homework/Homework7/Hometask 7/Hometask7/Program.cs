using System;
using System.Collections.Generic;

namespace Hometask7
{
    internal class Program
    {
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
            var isParsed = double.TryParse(data.Replace(".", "."), out value);

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
            Shape readedShape = null;

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

        public static List<Shape> ReadListOfShapes(int count)
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

        public static void PrintListOfShapes(List<Shape> listOfShapes)
        {
            foreach (var shape in listOfShapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }

        public static Shape GetShapeWithTheLargestPerimeter(List<Shape> listOfShapes)
        {
            var shapeWithMaxPerimeter = listOfShapes[0];

            for (var i = 1; i < listOfShapes.Count; i++)
            {
                if (shapeWithMaxPerimeter.Perimeter() < listOfShapes[i].Perimeter())
                {
                    shapeWithMaxPerimeter = listOfShapes[i];
                }
            }

            return shapeWithMaxPerimeter;
        }

        public static void PrintShapeWithMaxPerimeter(Shape maxPerimeterShape)
        {
            Console.WriteLine("\nShape with the largest perimeter:");
            Console.WriteLine(maxPerimeterShape.ToString());
        }

        #endregion

        public static void RunProgram()
        {
            const int count = 3;
            var listOfShapes = ReadListOfShapes(count);
            PrintListOfShapes(listOfShapes);

            var maxPerimeterShape = GetShapeWithTheLargestPerimeter(listOfShapes);
            PrintShapeWithMaxPerimeter(maxPerimeterShape);

            listOfShapes.Sort();
            Console.WriteLine("\nShapes sorted by area:");
            PrintListOfShapes(listOfShapes);
        }

        static void Main(string[] args)
        {
            try
            {
                RunProgram();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
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