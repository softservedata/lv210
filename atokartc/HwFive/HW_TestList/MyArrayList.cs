using System;
using System.Collections;

namespace HwFive
{
    public class MyArrayList
    {
        /// <summary>
    	/// Fills array list from console.
    	/// </summary>
    	/// <param name="inputedValuesCount">The inputed values count.</param>
    	/// <returns>filled list</returns>
    	public ArrayList FilledFromConsole(int inputedValuesCount)
        {
            Console.WriteLine("Enter 10 integer numbers one by one separated by space.");

            ArrayList arrayList = new ArrayList(inputedValuesCount);

            return arrayList;
        }
        /// <summary>
        /// Finds the elements position.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public void FindElementsPosition(ArrayList arrayList, int element)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int)arrayList[i] == element)
                {
                    Console.WriteLine("Positions of element {0} in the arrayList {1}", element, i);
                }
            }
        }
        /// <summary>
        /// Inserts the elements to array list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        /// <param name="index">The index.</param>
        /// <returns>array list with inserted elements</returns>
        public ArrayList InsertElements(ArrayList arrayList, int[] element = null, int[] index = null)
        {
            for (int i = 0; i < element.Length; i++)
            {
                arrayList.Insert(index[i], element[i]);
            }

            PrintList(arrayList);

            return arrayList;
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void PrintList(ArrayList arrayList)
        {
            foreach (int elem in arrayList)
            {
                Console.Write("{0} ", elem);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Removes the elements from the list and prints it.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public void RemoveElementsAndPrintList(ArrayList arrayList, int element)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int)arrayList[i] > element)
                {
                    arrayList.RemoveAt(i);
                }
            }
            PrintList(arrayList);
        }
        /// <summary>
        /// Sorts the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Sorted list</returns>
        public ArrayList SortList(ArrayList arrayList)
        {
            arrayList.Sort();

            return arrayList;
        }

    }
}
