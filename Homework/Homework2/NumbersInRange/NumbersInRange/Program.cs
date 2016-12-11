using System;
using System.Security.AccessControl;

namespace NumbersInRange
{
    ///<summary>
    ///User enter 3 float numbers and program verify whether they are all from range [a,b].
    ///</summary>

    class Program
    {
        public static float[] ConvertToFloatArray(string[] array)
        {
            var convertedArray = new float[array.Length];
            var parser = new DataParser();

            for (var i = 0; i < convertedArray.Length; i++)
            {
                convertedArray[i] = parser.Parse(array[i]);
            }

            return convertedArray;
        }

        public static Number<float>[] CreateArrayOfNumbers(float[] array)
        {
            var arrayOfNumbers = new Number<float>[array.Length];

            for (var i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = new Number<float>(array[i]);
            }

            return arrayOfNumbers;
        }

        public static bool AreFromOneRange(Number<float>[] objectsOfClassNumber, float a, float b)
        {
            var areAllInRange = true;

            foreach (var number in objectsOfClassNumber)
            {
                if (!number.IsInRange(a, b))
                {
                    areAllInRange = false;
                    break;
                }
            }

            return areAllInRange;
        }

        public static void PrintArrayOfNumbers(Number<float>[] array)
        {
            foreach (var number in array)
            {
                Console.WriteLine($"{number.Value} ");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                var count = 3;
                float a = -5;
                float b = 5;
                char[] symbols = { '-', ' ' };

                Console.WriteLine($"Please, enter {count} float numbers:");
                var enteredNumbers = Console.ReadLine();
                var arrayOfStringNumbers = enteredNumbers?.Split(symbols, count);

                var arrayOfFloatNumbers = ConvertToFloatArray(arrayOfStringNumbers);
                var objectsOfClassNumber = CreateArrayOfNumbers(arrayOfFloatNumbers);

                var areFromOneRange = AreFromOneRange(objectsOfClassNumber, a, b);
                Console.Write("\nNumbers \n");
                PrintArrayOfNumbers(objectsOfClassNumber);
                Console.WriteLine($"are from interval [{a},{b}] - {areFromOneRange}");
            }
            catch (FormatException ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
