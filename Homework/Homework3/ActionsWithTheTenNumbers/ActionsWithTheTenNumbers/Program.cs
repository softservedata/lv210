using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithTheTenNumbers
{
    ///<summary>
    ///User enters 10 numbers.
    ///This program add first five elements of array
    ///if they all are positive
    ///and multiply last five elements in another case.
    ///</summary>
    
    using FunctionsWithArray;
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputedArray = new int[10];

            Console.WriteLine("Please, enter 10 integer numbers:");
            bool isValid = true;
            for(int i = 0; i<10; i++)
            {
                isValid = int.TryParse(Console.ReadLine(), out inputedArray[i]);
                if (!isValid)
                {
                    Console.WriteLine("\nIncorrect data!");
                    break;
                }
            }

            if (isValid)
            {
                bool IsFirstFivePossitive = Functions.ArePositive(inputedArray, 5);

                if (IsFirstFivePossitive) Console.WriteLine("\nSum of first five elements - {0}", Functions.SumOfFirstElements(inputedArray, 5));
                else Console.WriteLine("\nProduct of last five elements - {0}", Functions.ProductOfLastElements(inputedArray, 5));
            }

            Console.ReadLine();
        }

    }
}
