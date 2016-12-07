using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithSquare
{
    ///<summary>
    ///This program calculates the square and periment of quadrate.
    ///</summary>

    class Program
    {
        public static string ReadData()
        {
            Console.Write("Please, enter side length of square:\na = ");
            var readedData = Console.ReadLine();

            return readedData;
        }

        static void Main(string[] args)
        {
            try
            {
                var readedData = ReadData();
                var dataParser = new DataParser();
                var size = dataParser.Parse(readedData);
                var square = new Square(size);

                Console.WriteLine(square);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
