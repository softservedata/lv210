using System;

namespace WorkWithSquare
{
    public class ProgramSquare
    {
        public int Square(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Length of the side can't be less or equal zero!");
            }

            return size * size;
        }

        public int Perimeter(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Length of the side can't be less or equal zero!");
            }

            return 4 * size;
        }

        public void Run()
        {
            try
            {
                var readedData = ReadData();
                var size = ParseData(readedData);

                DisplaySquareParametrs(size);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        public void DisplaySquareParametrs(int size)
        {         
            var square = Square(size);
            var perimeter = Perimeter(size);

            Console.WriteLine("\nArea = {0}", square);
            Console.WriteLine("Periment = {0}\n", perimeter);
        }

        public string ReadData()
        {
            Console.Write("Please, enter side length of square:\na = ");
            var readedData = Console.ReadLine();

            return readedData;
        }

        public int ParseData(string data)
        {
            int parsedValue;

            var isParseSuccessful = int.TryParse(data, out parsedValue);

            if(!isParseSuccessful)
            {
                throw new FormatException("Can't parse data to <int>");
            }

            return parsedValue;
        }
    }
}