using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsTask
{
    class ListOperations
    {
        public void PrintList(IEnumerable printList)
        {
            foreach (var item in printList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

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

        public void InsertElements(List<int> list)
        {
            list.Insert(2, 1);
            list.Insert(8, -3);
            list.Insert(5, -4);

            Console.Write("List with inserted elements: ");
            PrintList(list);
        }
    }
}
