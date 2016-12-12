using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    /// <summary>
    /// Read 3 integres and write max and min of them.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            //Entering numbers
            Console.Write("Enter 3 numbers: ");
            string stringOfValues = Console.ReadLine();

            //Converting entering data
            string[] arrayStrings = stringOfValues.Split(' ');
            int[] arrayInts = new int[3];
            ConvertStringToInt(arrayStrings, arrayInts);

            //Result print
            Console.WriteLine("---------Result-------------");
            Console.WriteLine("Max Value: {0}", MaxValue(arrayInts));
            Console.WriteLine("Min Value: {0}", MinValue(arrayInts));
        }

        public static int[] ConvertStringToInt(string[] arrayStrings, int[] arrayInts)
        {
            for (int i = 0; i < arrayInts.Length; i++)
            {
                Int32.TryParse(arrayStrings[i], out arrayInts[i]);
            }
            return arrayInts;
        }

        public static int MaxValue(int[] arrayInts)
        {
            int maxValue = Int32.MinValue;
            for (int i = 0; i < arrayInts.Length; i++)
            {
                if (arrayInts[i] > maxValue)
                {
                    maxValue = arrayInts[i];
                }
            }
            return maxValue;
        }

        public static int MinValue(int[] arrayInts)
        {
            int minValue = Int32.MaxValue;
            for (int i = 0; i < arrayInts.Length; i++)
            {
                if (arrayInts[i] < minValue)
                {
                    minValue = arrayInts[i];
                }
            }
            return minValue;
        }
    }
}
