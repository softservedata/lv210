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

        static void Main(string[] args)
        {
            Console.Write("Input side lenght for polygons: ");
            try
            {
                double sideLength = ParseAtempt(Console.ReadLine());

                EquilateralTriangle myTriangle = new EquilateralTriangle(sideLength);
                myTriangle.TriangleCalculation();

                Square mySquare = new Square(sideLength);
                mySquare.SquareCalculation();

                Pentagon myPentagon = new Pentagon(sideLength);
                myPentagon.PentagonCalculation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
