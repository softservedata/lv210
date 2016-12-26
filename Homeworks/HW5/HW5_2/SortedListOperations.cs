using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsTask
{
    public class SortedListOperations
    {
        public void PrintList(IEnumerable printList)
        {
            foreach (var item in printList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

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
            PrintList(PositionsList);
        }

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
            PrintList(sortedList);
        }

        public void InsertElements(SortedList sortedList)
        {
            sortedList.SetByIndex(2, 1);
            sortedList.SetByIndex(8, -3);
            sortedList.SetByIndex(5, -4);

            Console.Write("SortedList with inserted elements: ");
            PrintList(sortedList);
        }

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
