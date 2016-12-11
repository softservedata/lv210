using System;

namespace Polygons
{
    public class PolygonsActions
    {
        public static double ParseAtempt()
        {
            double ReadVariable;
            bool ParseAtempt = double.TryParse(Console.ReadLine(), out ReadVariable);
            if (ParseAtempt && ReadVariable > 0)
            {
                return ReadVariable;
            }
            else
            {
                throw new FormatException("Please, input positive <double> data");
            }
        }
        public static void TriangleAction(double SideLength)
        {
            EquilateralTriangle MyTriangle = new EquilateralTriangle(SideLength);
            MyTriangle.PerimeterCalculation();
            MyTriangle.AreaCalculation();
            MyTriangle.Display();
        }
        public static void SquareAction(double SideLength)
        {
            Square MySquare = new Square(SideLength);
            MySquare.PerimeterCalculation();
            MySquare.AreaCalculation();
            MySquare.Display();
        }
        public static void PentagonAction(double SideLength)
        {
            Pentagon MyPentagon = new Pentagon(SideLength);
            MyPentagon.PerimeterCalculation();
            MyPentagon.AreaCalculation();
            MyPentagon.Display();
        }
        static void Main(string[] args)
        {
            Console.Write("Input side lenght for polygons: ");
            try
            {
                double SideLength = ParseAtempt();
                TriangleAction(SideLength);
                SquareAction(SideLength);
                PentagonAction(SideLength);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
