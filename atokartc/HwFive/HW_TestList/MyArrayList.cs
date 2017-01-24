using System;
using System.Collections;
using System.Linq;

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
            ArrayList arrayList = new ArrayList(inputedValuesCount);

            return arrayList;
        }
        /// <summary>
        /// Finds the elements position.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        public int FindElementsPosition(ArrayList arrayList, int element)
        {
            int elementsPosition = -1;
            bool isPresentInList;

            for (int i = 0; i < arrayList.Count; i++)
            {
                isPresentInList = ((int)arrayList[i] == element);
                if (isPresentInList)
                {
                    elementsPosition = i;
                }
            }
            return elementsPosition;
        }
        /// <summary>
        /// Inserts the elements to array list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="element">The element.</param>
        /// <param name="index">The index.</param>
        /// <returns>array list with inserted elements</returns>
        public ArrayList InsertElements(ArrayList arrayList, int[] element, int[] index)
        {
            for (int i = 0; i < element.Length; i++)
            {
                arrayList.Insert(index[i], element[i]);
            }

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
        /// Removes the elements from the list if it's bigger than specified element.
        /// </summary>
        /// <param name="arrayList">The list.</param>
        /// <param name="element">The element.</param>
        public ArrayList RemoveElementsLessThanSpecified(ArrayList arrayList, int element)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int)arrayList[i] > element)
                {
                    arrayList.RemoveAt(i);
                    arrayList.TrimToSize();
                }
            }
            return arrayList;
        }
        /// <summary>
        /// Removes the elements from the array list if it's equals than specified element.
        /// </summary>
        /// <param name="arrayList">The list.</param>
        /// <param name="element">The element.</param>
        public ArrayList RemoveElementFromList(ArrayList arrayList, int element)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int)arrayList[i] == element)
                {
                    arrayList.RemoveAt(i);
                    arrayList.TrimToSize();
                }
            }
            return arrayList;
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
