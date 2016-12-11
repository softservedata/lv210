using System;

namespace MaxMin
{
    ///<summary>
    ///This program find max and min value in array of numbers.
    ///</summary>

    class Program
    {
        public static int[] ConvertArray(string[] arrayStrings)
        {
            int[] resultArray = new int[arrayStrings.Length];
            var parser = new DataParser();

            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = parser.Parse(arrayStrings[i]);
            }

            return resultArray;
        }

        public static void PrintArray(int[] array)
        {
            var arrayToString = String.Join(" ", array);
            Console.WriteLine("\nYour array is:");
            Console.WriteLine(arrayToString);
        }

        public static void PrintMaxMinValues(int max, int min)
        {
            Console.WriteLine("\nResults:");
            Console.WriteLine("Max - {0} ", max);
            Console.WriteLine("Min - {0} ", min);
        }

        public static int ReadAndParseCountOfNumbers()
        {
            Console.WriteLine("How many numbers you want to enter?");
            var readedCount = Console.ReadLine();
            var parser = new DataParser();

            return parser.Parse(readedCount);
        }

        public static string ReadSequanceOfNumbers(int countOfNumbers)
        {
            Console.WriteLine($"\nPlease, enter {countOfNumbers} numbers:");
            var readedSequance = Console.ReadLine();

            return readedSequance;
        }

        static void Main(string[] args)
        {
            try
            {
                var countOfNumbers = ReadAndParseCountOfNumbers();
                var sequanceOfNumbers = ReadSequanceOfNumbers(countOfNumbers);

                char[] seperators = { ' ', '-' };
                //if readedSequance is not null
                string[] readedArray = sequanceOfNumbers?.Split(seperators, countOfNumbers);
                int[] arrayOfNumbers = ConvertArray(readedArray);

                var max = ArrayExtentions<int>.Max(arrayOfNumbers);
                var min = ArrayExtentions<int>.Min(arrayOfNumbers);

                PrintArray(arrayOfNumbers);
                PrintMaxMinValues(max, min);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        
            Console.ReadLine();
        }
    }
}
