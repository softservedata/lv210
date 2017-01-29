using System;
using System.Collections;

namespace HwFive
{
    public class MySortedList
    {
        private int GetInteger()
        {
            int readedVar = 0;
            bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered == false)
            {
                Console.WriteLine("Please, enter an positive integer");
                return this.GetInteger();
            }
            return readedVar;
        }
        /// <summary>
    	/// Fills sorted list from console.
    	/// </summary>
    	/// <param name="inputedValuesCount">The inputed values count.</param>
    	/// <returns>filled sorted list</returns>
    	public SortedList FillFromConsole(int inputedValuesCount)
        {
            SortedList list = new SortedList(inputedValuesCount);

            for (int i = 0; i < list.Count; i++)
            {
                list.Add(i, GetInteger());
            }

            list.TrimToSize();
            return list;
        }
        /// <summary>
        /// Finds the elements position.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="elementToFind">The element.</param>
        public int FindElementsPosition(SortedList sortedList, int elementToFind)
        {
            int elementsPosition = -1;
            bool isPresentInList;

            for (int i = 0; i < sortedList.Count; i++)
            {
                isPresentInList = ((int)sortedList.GetByIndex(i) == elementToFind);
                if (isPresentInList)
                {
                    elementsPosition = i;
                }
            }
            return elementsPosition;
        }
        /// <summary>
        /// Inserts the elements to sorted list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        /// <param name="index">The index.</param>
        /// <returns>list with inserted elements</returns>
        public SortedList InsertElements(SortedList sortedList, int[] element, int[] index)
        {
            for (int i = 0; i < element.Length; i++)
            {
                sortedList.SetByIndex(index[i], element[i]);
            }
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
        /// Removes the elements from the sorted list if it's bigger than specified element.
        /// </summary>
        /// <param name="sortedList">The list.</param>
        /// <param name="element">The element.</param>
        public SortedList RemoveElementsLessThanSpecified(SortedList sortedList, int element)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int)sortedList.GetByIndex(i) > element)
                {
                    sortedList.RemoveAt(i);
                    sortedList.TrimToSize();
                }
            }
            return sortedList;
        }
        /// <summary>
        /// Removes the elements from the sorted list if it's equals than specified element.
        /// </summary>
        /// <param name="sortedList">The list.</param>
        /// <param name="element">The element.</param>
        public SortedList RemoveElementFromList(SortedList sortedList, int element)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int)sortedList.GetByIndex(i) == element)
                {
                    sortedList.RemoveAt(i);
                    sortedList.TrimToSize();
                }
            }
            return sortedList;
        }
    }
}
