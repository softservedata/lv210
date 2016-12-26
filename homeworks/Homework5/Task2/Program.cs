using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    public class Program
    {
        //Converts input string to array of integers.
        public static int[] ConvertStringToArray(string input)
        {
            char[] separators = {' ', ',', ';', '.'};
            string[] inputList = input.Split(separators);

            int[] convertedInput = new int[inputList.Length];
            try
            {
                for (int i = 0; i < inputList.Length; i++)
                {
                    convertedInput[i] = Convert.ToInt32(inputList[i]);
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Can not convert to integer");
            }

            return convertedInput;
        }


        public static void PrintValues(IEnumerable list)
        {
            foreach (var item in list)
            {
                Console.Write(" {0}", item);
            }
        }

        public static void TestList()
        {
            string input = Console.ReadLine();
            List<int> myColl = new List<int>((ConvertStringToArray(input)));
            Console.WriteLine("Integers list");
            PrintValues(myColl);

            Console.WriteLine("\nRemove values greater than");
            int valueToRemove = Convert.ToInt32(Console.ReadLine());
            myColl.RemoveAll(value => value > valueToRemove);
            PrintValues(myColl);

            Console.WriteLine("\nInserting values 1,-3,-4 to positions 2,8,5:");
            try
            {
                myColl.Insert(2, 1);
                myColl.Insert(8, -3);
                myColl.Insert(5, -4);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index of element is out of range");
            }

            PrintValues(myColl);

            Console.WriteLine("\nSorted list:");
            myColl.Sort();
            PrintValues(myColl);
        }

        public static void TestArrayList()
        {
            string input = Console.ReadLine();
            ArrayList myColl = new ArrayList((ConvertStringToArray(input)));
            Console.WriteLine("Integers array list");
            PrintValues(myColl);

            Console.WriteLine("\nAll positions of -10:");
            PrintValues(ArrayListUtils.FindPositions(myColl, -10));

            Console.WriteLine("\nRemove values greater than");
            int valueToRemove = Convert.ToInt32(Console.ReadLine());
            ArrayListUtils.RemoveAllGreaterThan(myColl, valueToRemove);
            PrintValues(myColl);

            Console.WriteLine("\nInserting values 1,-3,-4 to positions 2,8,5:");
            try
            {
                myColl.Insert(2, 1);
                myColl.Insert(8, -3);
                myColl.Insert(5, -4);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index of element is out of range");
            }
            PrintValues(myColl);

            Console.WriteLine("\nSorted list:");
            myColl.Sort();
            PrintValues(myColl);
        }

        /*public static void TestSortedList()
        {
            //Reading string from console
            string input = Console.ReadLine();

            //Converting string to array of integers
            int[] inputArray = (ConvertStringToArray(input));

            SortedList myColl = new SortedList();

            //Adding values to sorted list
            for (int i = 0; i < inputArray.Length; i++)
            {
                myColl.Add(i, inputArray[i]);
            }

            Console.WriteLine("Sorted list");
            PrintValues(myColl.Values);

            Console.WriteLine("\nAll positions of -10:");
            PrintValues(ListUtils.FindPositions(myColl, -10));

            Console.WriteLine("\nInserting values 1,-3,-4 to positions 2,8,5:");
            myColl.SetByIndex(2, 1);
            myColl.SetByIndex(8, -3);
            myColl.SetByIndex(5, -4);
            PrintValues(myColl.Values);

            Console.WriteLine("\nRemove values greater than");
            int valueToRemove = Convert.ToInt32(Console.ReadLine());
            ListUtils.RemoveAllGreaterThan(myColl, valueToRemove);
            PrintValues(myColl.Values);
        }*/

        static void Main(string[] args)
        {
            Console.WriteLine("Input list of integer numbers and press <enter>");
            //TestList();
            TestArrayList();
            //TestSortedList();
            Console.ReadKey();
        }
    }
}
