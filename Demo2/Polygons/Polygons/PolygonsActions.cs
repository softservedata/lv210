using System;

namespace Polygons
{
    public class PolygonsActions
    {
        /// <summary>
        /// Method for verification of inputed data 
        /// </summary>
        /// <returns>Inputed data or throw exception</returns>
        public static double ParseAtempt(string inputedData)
        {
            double readVariable;
            bool parseAtempt = double.TryParse(inputedData, out readVariable);
            if (parseAtempt && readVariable > 0)
            {
                return readVariable;
            }
            else
            {
                throw new FormatException("Please, input positive <double> number");
            }
        }
        /// <summary>
        /// Create object of "EquilateralTriangle" class, calculate perimeter and area of triangle using methods "PerimeterCalculation()"
        /// and "AreaCalculation()". All information displays using method "Display()"
        /// </summary>
        /// <param name="sideLength"></param>
        public static void TriangleCalculation(double sideLength)
        {
            EquilateralTriangle myTriangle = new EquilateralTriangle(sideLength);
            myTriangle.PerimeterCalculation();
            myTriangle.AreaCalculation();
            myTriangle.Display();
        }
        /// <summary>
        /// Create object of "Square" class, calculate perimeter and area of square using methods "PerimeterCalculation()"
        /// and "AreaCalculation()". All information displays using method "Display()"
        /// </summary>
        /// <param name="sideLength"></param>
        public static void SquareCalculation(double sideLength)
        {
            Square mySquare = new Square(sideLength);
            mySquare.PerimeterCalculation();
            mySquare.AreaCalculation();
            mySquare.Display();
        }
        /// <summary>
        /// Create object of "Pentagon" class, calculate perimeter and area of pentagon using methods "PerimeterCalculation()"
        /// and "AreaCalculation()". All information displays using method "Display()"
        /// </summary>
        /// <param name="sideLength"></param>
        public static void PentagonCalculation(double sideLength)
        {
            Pentagon myPentagon = new Pentagon(sideLength);
            myPentagon.PerimeterCalculation();
            myPentagon.AreaCalculation();
            myPentagon.Display();
        }

        static void Main(string[] args)
        {
            Console.Write("Input side lenght for polygons: ");
            try
            {
                double sideLength = ParseAtempt(Console.ReadLine());
                TriangleCalculation(sideLength);
                SquareCalculation(sideLength);
                PentagonCalculation(sideLength);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
