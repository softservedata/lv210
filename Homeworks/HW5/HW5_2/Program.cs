using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsTask
{
    public class Program
    {
        /// <summary>
        /// Method for parsing inputed data in to <int> data type
        /// </summary>
        /// <param name="inputedData"></param>
        /// <param name="numberCount"></param>
        /// <returns>Array of integers</returns>
        static int[] ParseAtempt(string inputedData, int numberCount)
        {
            Console.Write("Input 10 <int> values devided by space: ");
            int[] valuesArray = new int[numberCount];
            int ParsedValues;
            valuesArray = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select
                                                    (i => int.TryParse(i, out ParsedValues) ? ParsedValues : 0).ToArray();
            return valuesArray;
        }

        /// <summary>
        /// Work with list and operations related to it
        /// </summary>
        static void TestList()
        {
            int numberCount = 10;
            List<int> valuesList = new List<int>();
            ListOperations testList = new ListOperations();

            valuesList = testList.FromArrayToListData(ParseAtempt(Console.ReadLine(), numberCount));
            testList.FindAndPrintElementPositions(valuesList, -10);
            testList.RemoveElement(valuesList, 20);
            testList.InsertElements(valuesList);
        }

        /// <summary>
        /// Work with arraylist and operations related to it
        /// </summary>
        static void TestArrayList()
        {
            int numberCount = 10;
            ArrayList valuesArrayList = new ArrayList();
            ArrayListOperations testArrayList = new ArrayListOperations();

            valuesArrayList = testArrayList.FromArrayToArrayListData(ParseAtempt(Console.ReadLine(), numberCount));
            testArrayList.FindAndPrintElementPositions(valuesArrayList, -10);
            testArrayList.RemoveElement(valuesArrayList, 20);
            testArrayList.InsertElements(valuesArrayList);
        }

        /// <summary>
        /// Work with sorted list and operations related to it
        /// </summary>
        static void TestSortedList()
        {
            int numberCount = 10;
            SortedList valuesSortedList = new SortedList();
            SortedListOperations testSortedList = new SortedListOperations();

            valuesSortedList = testSortedList.FromArrayToSortedListData(ParseAtempt(Console.ReadLine(), numberCount));
            testSortedList.FindAndPrintElementPositions(valuesSortedList, -10);
            testSortedList.RemoveElement(valuesSortedList, 20);
            testSortedList.InsertElements(valuesSortedList);
        }

        static void Main(string[] args)
        {
            TestList();
            TestArrayList();
            TestSortedList();

            Console.ReadLine();
        }
    }
}
