using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsTask
{
    class ArrayListOperations
    {
        public void PrintList(IEnumerable printList)
        {
            foreach (var item in printList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        public void FindAndPrintElementPositions(ArrayList arrayList, int findElement)
        {
            List<int> PositionsList = new List<int>();
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int)arrayList[i] == findElement)
                {
                    PositionsList.Add(i);
                }
            }
            Console.Write("Indexes of '-10' elements: ");
            PrintList(PositionsList);
        }

        public void RemoveElement(ArrayList arrayList, int removedElement)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int)arrayList[i] > removedElement)
                {
                    arrayList.RemoveAt(i);
                }
            }
            Console.Write("ArrayList without elements greater then 20: ");
            PrintList(arrayList);
        }

        public void InsertElements(ArrayList arrayList)
        {
            arrayList.Insert(2, 1);
            arrayList.Insert(8, -3);
            arrayList.Insert(5, -4);

            Console.Write("ArrayList with inserted elements: ");
            PrintList(arrayList);
        }
    }
}
