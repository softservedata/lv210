using System;
using System.Collections;

namespace HwFive
{
    public class MySortedList
    {
        /// <summary>
    	/// Fills sorted list from console.
    	/// </summary>
    	/// <param name="inputedValuesCount">The inputed values count.</param>
    	/// <returns>filled sorted list</returns>
    	public SortedList FilledFromConsole(int inputedValuesCount)
        {
            Console.WriteLine("Enter 10 integer numbers one by one separated by space.");

            SortedList list = new SortedList(inputedValuesCount);

            return list;
        }
        /// <summary>
        /// Finds the elements position.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public void FindElementsPosition(SortedList sortedList, int element)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int)sortedList.GetByIndex(i) == element)
                {
                    Console.WriteLine("Positions of element {0} in the arrayList {1}", element, i);
                }
            }
        }
        /// <summary>
        /// Inserts the elements to sorted list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        /// <param name="index">The index.</param>
        /// <returns>list with inserted elements</returns>
        public SortedList InsertElements(SortedList sortedList, int[] element = null, int[] index = null)
        {
            for (int i = 0; i < element.Length; i++)
            {
                sortedList.SetByIndex(index[i], element[i]);
            }

            PrintList(sortedList);

            return sortedList;
        }
        /// <summary>
        /// Prints the sorted list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void PrintList(SortedList sortedList)
        {
            foreach (int elem in sortedList)
            {
                Console.Write("{0} ", elem);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Removes the elements from the sorted list and prints it.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public void RemoveElementsAndPrintList(SortedList sortedList, int element)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int)sortedList.GetByIndex(i) > element)
                {
                    sortedList.RemoveAt(i);
                }
            }
            PrintList(sortedList);
        }
    }
}
