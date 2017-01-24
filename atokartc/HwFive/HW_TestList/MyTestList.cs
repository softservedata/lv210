using System;
using System.Collections;
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
    	/// <returns>filled list. If not int entered then 0 added instead</returns>
    	public List<int> FillFromConsole(int inputedValuesCount)
        {
            int parsedValue = 0;
            List<int> list = new List<int>(inputedValuesCount);

            list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(s => Int32.TryParse(s, out parsedValue) ? parsedValue : 0).ToList<int>();

            return list;
        }
        /// <summary>
        /// Finds the elements position.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="elementToFind">The element.</param>
        public int FindElementsPosition(List<int> list, int elementToFind)
        {
            int elementsPosition = -1;
            bool isPresentInList;

            for (int i = 0; i < list.Count; i++)
            {
                isPresentInList = (list.ElementAt(i) == elementToFind);
                if (isPresentInList)
                {
                    elementsPosition = i;
                }
            }
            return elementsPosition;
        }
        /// <summary>
        /// Inserts the elements to list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        /// <param name="index">The index.</param>
        /// <returns>list with inserted elements</returns>
        public IList InsertElements(IList list, int[] element, int[] index)
        {
            for (int i = 0; i < element.Length; i++)
            {
                list.Insert(index[i], element[i]);
            }
            return list;
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void PrintList(IList list)
        {
            foreach (int elem in list)
            {
                Console.Write("{0} ", elem);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Removes the elements from the list if it's equals than specified element.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public List<int> RemoveElementFromList(List<int> list, int element)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i) == element)
                {
                    list.RemoveAt(i);
                    list.TrimExcess();
                }
            }
            return list;
        }
        /// <summary>
        /// Removes the elements from the list if it's bigger than specified element.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public List<int> RemoveElementsLessThanSpecified(List<int> list, int element)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i) > element)
                {
                    list.RemoveAt(i);
                    list.TrimExcess();
                }
            }
            return list;
        }
        /// <summary>
        /// Sorts the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Sorted list</returns>
        public List<int> SortList(List<int> list)
        {
            int temp;
            int element;
            int nextElement;

            for (int i =  0; i < list.Count -1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    element = list.ElementAt(i);
                    nextElement = list.ElementAt(j);
                    if (element < nextElement)
                    {
                        temp = list.ElementAt(i);
                        element = list.ElementAt(j);
                        nextElement = temp;
                    }
                }
            }
            return list;
        }
    }
}
