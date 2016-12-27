using System;
using System.Collections.Generic;
using System.Linq;

namespace HwFive
{
    public class MyTestList
    {
        /// <summary>
    	/// Fills list from console.
    	/// </summary>
    	/// <param name="inputedValuesCount">The inputed values count.</param>
    	/// <returns>filled list</returns>
    	public List<int> FilledFromConsole(int inputedValuesCount)
        {
            int parsedValue = 0;

            Console.WriteLine("Enter 10 integer numbers one by one separated by space.");

            List<int> list = new List<int>(inputedValuesCount);
            list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(s => Int32.TryParse(s, out parsedValue) ? parsedValue : 0).ToList();

            return list;
        }
        /// <summary>
        /// Finds the elements position.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public void FindElementsPosition(List<int> list, int element)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i) == element)
                {
                    Console.WriteLine("Positions of element {0} in the arrayList {1}", element, i);
                }
            }
        }
        /// <summary>
        /// Inserts the elements to list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        /// <param name="index">The index.</param>
        /// <returns>list with inserted elements</returns>
        public List<int> InsertElements(List<int> list, int[] element = null, int[] index = null)
        {
            for (int i = 0; i < element.Length; i++)
            {
                list.Insert(index[i], element[i]);
            }

            PrintList(list);

            return list;
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void PrintList(List<int> list)
        {
            foreach (int elem in list)
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
        public void RemoveElementsAndPrintList(List<int> list, int element)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i) > element)
                {
                    list.RemoveAt(i);
                }
            }
            PrintList(list);
        }
        /// <summary>
        /// Sorts the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Sorted list</returns>
        public List<int> SortList(List<int> list)
        {
            list.Sort();

            return list;
        }
    }
}
