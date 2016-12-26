using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsTask
{
    public class ArrayListOperations
    {
        /// <summary>
        /// Method for printing  arraylist to console
        /// </summary>
        /// <param name="printList"></param>
        public void PrintArrayList(IEnumerable printList)
        {
            foreach (var item in printList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method for finding indexes of particular element in arraylist
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="findElement"></param>
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
            PrintArrayList(PositionsList);
        }

        /// <summary>
        /// Method for removing particular element from the arraylist
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="removedElement"></param>
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
            PrintArrayList(arrayList);
        }

        /// <summary>
        /// Method for inserting elements into arraylist
        /// </summary>
        public void InsertElements(ArrayList arrayList)
        {
            arrayList.Insert(2, 1);
            arrayList.Insert(8, -3);
            arrayList.Insert(5, -4);

            Console.Write("ArrayList with inserted elements: ");
            PrintArrayList(arrayList);
        }

        /// <summary>
        /// Method for transferring values from array into arraylist
        /// </summary>
        /// <param name="valuesArray"></param>
        /// <returns></returns>
        public ArrayList FromArrayToArrayListData(int[] valuesArray)
        {
            ArrayList arrayList = new ArrayList();

            for (int i = 0; i < valuesArray.Length; i++)
            {
                arrayList[i] = valuesArray[i];
            }
            return arrayList;
        }
    }
}
