using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task2
{
    class Program
    {
        /// <summary>
        /// Task Description : read 3 integres and write max and min of them.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Input 3 integer numbers divided by space : ");
            string[] inputIntegerData = Console.ReadLine().Split(' ');

            List<int> listOfNumbers = new List<int>();

            for (int i = 0; i < inputIntegerData.Length; i++)
            {
                listOfNumbers.Add(int.Parse(inputIntegerData[i]));
            }

            int minValue = listOfNumbers.Min();
            int maxValue = listOfNumbers.Max();

            Console.WriteLine("Min value : {0}, max value : {1}", minValue, maxValue);

            Console.ReadKey();
        }
        
    }
}
