using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsTask
{
    public class ListOperations
    {
        /// <summary>
        /// Method for printing list to console
        /// </summary>
        /// <param name="printList"></param>
        public void PrintList(IEnumerable printList)
        {
            foreach (var item in printList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method for finding indexes of particular element in list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="findElement"></param>
        public void FindAndPrintElementPositions(List<int> list, int findElement)
        {
            List<int> PositionsList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == findElement)
                {
                    PositionsList.Add(i);
                }
            }
            Console.Write("Indexes of '-10' elements: ");
            PrintList(PositionsList);
        }

        /// <summary>
        /// Method for removing particular element from the list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="removedElement"></param>
        public void RemoveElement(List<int> list, int removedElement)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i) > removedElement)
                {
                    list.RemoveAt(i);
                }
            }
            Console.Write("List without elements greater then 20: ");
            PrintList(list);
        }

        /// <summary>
        /// Method for inserting elements into list
        /// </summary>
        /// <param name="list"></param>
        public void InsertElements(List<int> list)
        {
            list.Insert(2, 1);
            list.Insert(8, -3);
            list.Insert(5, -4);

            Console.Write("List with inserted elements: ");
            PrintList(list);
        }

        /// <summary>
        /// Method for transferring values from array into list
        /// </summary>
        /// <param name="valuesArray"></param>
        /// <returns>List with data</returns>
        public List<int> FromArrayToListData(int[] valuesArray)
        {
            List<int> list = new List<int>();

            foreach (int value in valuesArray)
            {
                list.Add(value);
            }
            return list;
        }
    }
}
