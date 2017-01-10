using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// A) Add to class method  static void TestList() and put in it code for solving next tasks:
    ///   1) Declare List myColl of integers and fill it from Console by 10 integer numbers.
    ///   2) Find and print all positions of element -10 in the list.
    ///   3) Remove from list elements, which are greater then 20.
    ///   4) Insert elements 1,-3,-4 in the positions 2, 8, 5.
    ///   5) Sort and print list
    /// B) Add to class method  static void TestArrayList() and static void TestSortedList() for solving the same tasks
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Converts input string to array of integers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>int[]</returns>
        public static int[] ConvertStringToArray(string input)
        {
            char[] separators = {' ', ',', ';', '.'};
            string[] inputList = input.Split(separators);

            int[] convertedInput = new int[inputList.Length];
            try
            {
                for (int i = 0; i < inputList.Length; i++)
                {
                    convertedInput[i] = int.Parse(inputList[i]);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Can not convert to integer");
            }

            return convertedInput;
        }

        /// <summary>
        /// Prints all values of IEnumerable
        /// </summary>
        /// <param name="list"></param>
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

            Console.WriteLine("\nAll positions of -10:");
            List<int> positions = ListUtils.FindPositions(myColl, -10);
            PrintValues(positions);

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
            List<int> positions = ArrayListUtils.FindPositions(myColl, -10);
            PrintValues(positions);

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

        public static void TestSortedList()
        {
            string input = Console.ReadLine();

            int[] inputArray = (ConvertStringToArray(input));
            SortedList myColl = new SortedList();

            for (int i = 0; i < inputArray.Length; i++)
            {
                myColl.Add(i, inputArray[i]);
            }

            Console.WriteLine("Sorted list");
            PrintValues(myColl.Values);

            Console.WriteLine("\nAll positions of -10:");
            List<int> positions = SortedListUtils.FindPositions(myColl, -10);
            PrintValues(positions);

            Console.WriteLine("\nInserting values 1,-3,-4 to positions 2,8,5:");

            try
            {
                myColl.SetByIndex(2, 1);
                myColl.SetByIndex(8, -3);
                myColl.SetByIndex(5, -4);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index of element is out of range");
            }

            PrintValues(myColl.Values);

            Console.WriteLine("\nRemove values greater than");
            int valueToRemove = Convert.ToInt32(Console.ReadLine());
            SortedListUtils.RemoveAllGreaterThan(myColl, valueToRemove);
            PrintValues(myColl.Values);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input list of integer numbers and press <enter>");
            TestList();
            TestArrayList();
            TestSortedList();
            Console.ReadKey();
        }
    }
}
