using System;

namespace Square
{
    class Program
    {
        ///<summary>
        ///	Define integer variable a.
        ///	Read the value of a from console and calculate area and perimetr of square with length a. 
        //	Output obtained results.
        ///</summary>
        public static int ParseAtempt()
        {
            int ReadVariable;
            bool ParseAtempt = Int32.TryParse(Console.ReadLine(), out ReadVariable);
            if (ParseAtempt)
            {
                return ReadVariable;
            }
            else
            {
                throw new FormatException("Wrong data type.");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Input length: ");
            try
            {
                int length = ParseAtempt();
                Square MySquare = new Square(length);
                int perimeter = MySquare.Perimeter();
                int area = MySquare.Area();
                Console.WriteLine("Perimetr = {0};\nArea = {1};", perimeter, area);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
