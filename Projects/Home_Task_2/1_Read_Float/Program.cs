using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Read_Float
{
    /// <summary>
    /// Read 3 float numbers and check: are they all belong to the range [-5,5]
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            //Reading of values
            Console.Write("Entert first number: ");
            float firstNumber = Convert.ToSingle(Console.ReadLine());

            Console.Write("Entert second number: ");
            float secondNumber = Convert.ToSingle(Console.ReadLine());

            Console.Write("Entert third number: ");
            float thirdNumber = Convert.ToSingle(Console.ReadLine());

            //Result print
            Console.WriteLine("All numbers belong to range [-5;5]: {0}", IsNumbersInRange(firstNumber, secondNumber, thirdNumber));
        }

        public static bool IsNumbersInRange(float firstNumb, float secondNumb, float thirdNumb)
        {
            float lowBoundary = -5;
            float hightBoundary = 5;

            return ((firstNumb >= lowBoundary) && (firstNumb <= hightBoundary)) && ((secondNumb >= lowBoundary) 
                && (secondNumb <= hightBoundary)) && ((thirdNumb >= lowBoundary) && (thirdNumb <= hightBoundary));
        }
    }
}
