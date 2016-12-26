using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsTask
{
    public class SortedListOperations
    {
        /// <summary>
        /// Method for printing sorted list to console
        /// </summary>
        /// <param name="printList"></param>
        public void PrintSortedList(IEnumerable printList)
        {
            foreach (var item in printList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method for finding indexes of particular element in sorted list
        /// </summary>
        /// <param name="sortedList"></param>
        /// <param name="findElement"></param>
        public void FindAndPrintElementPositions(SortedList sortedList, int findElement)
        {
            List<int> PositionsList = new List<int>();
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int)sortedList.GetByIndex(i) == findElement)
                {
                    PositionsList.Add(i);
                }
            }
            Console.Write("Indexes of '-10' elements: ");
            PrintSortedList(PositionsList);
        }

        /// <summary>
        /// Method for removing particular element from the sorted list
        /// </summary>
        /// <param name="sortedList"></param>
        /// <param name="removedElement"></param>
        public void RemoveElement(SortedList sortedList, int removedElement)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int)sortedList.GetByIndex(i) > removedElement)
                {
                    sortedList.RemoveAt(i);
                }
            }
            Console.Write("SortedList without elements greater then 20: ");
            PrintSortedList(sortedList);
        }

        /// <summary>
        /// Method for inserting elements into sorted list
        /// </summary>
        /// <param name="sortedList"></param>
        public void InsertElements(SortedList sortedList)
        {
            sortedList.SetByIndex(2, 1);
            sortedList.SetByIndex(8, -3);
            sortedList.SetByIndex(5, -4);

            Console.Write("SortedList with inserted elements: ");
            PrintSortedList(sortedList);
        }

        /// <summary>
        /// Method for transferring values from array into sorted list
        /// </summary>
        /// <param name="valuesArray"></param>
        /// <returns></returns>
        public SortedList FromArrayToSortedListData(int[] valuesArray)
        {
            SortedList sortedList = new SortedList();

            for (int i = 0; i < valuesArray.Length; i++)
            {
                sortedList[i] = valuesArray[i];
            }
            return sortedList;
        }
    }
}
