using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Utils class, which have additional methods to work with ArrayList and SortedList.
    /// </summary>
    public class ListUtils
    {
        //Removes all elements of array list, which are greater than specified value
        public static void RemoveAllFromArrayList(ArrayList arrayList, int value)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int) arrayList[i] > value) arrayList.Remove(arrayList[i]);
            }
        }

        //Removes all elements of sorted list, which are greater than specified value
        public static void RemoveAllFromSortedList(SortedList sortedList, int value)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int) sortedList.GetByIndex(i) > value)
                {
                    sortedList.RemoveAt(i);
                    i--;
                }
            }
        }

        //Finds all positions of specified value
        public static List<int> FindPositions(ArrayList list, int value)
        {
            List<int> positions = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if ((int) list[i] == value) positions.Add(i + 1);
            }

            return positions;
        }

        public static List<int> FindPositions(List<int> list, int value)
        {
            List<int> positions = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == value) positions.Add(i + 1);
            }

            return positions;
        }

        public static List<int> FindPositions(SortedList sortedList, int value)
        {
            List<int> positions = new List<int>();
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int) sortedList[i] == value) positions.Add(i + 1);
            }

            return positions;
        }
    }
}