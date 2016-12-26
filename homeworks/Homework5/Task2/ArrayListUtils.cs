using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Utils class, which have additional methods to work with ArrayList and SortedList.
    /// </summary>
    public class ArrayListUtils
    {
        //Removes all elements of array list, which are greater than specified value
        public  static void RemoveAllGreaterThan(ArrayList arrayList, int value)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int) arrayList[i] > value)
                {
                    arrayList.RemoveAt(i);
                    i--;
                }
            }
           

        }

      

        //Finds all positions of specified value
        public static List<int> FindPositions(ArrayList list, int value)
        {
            if (list == null||list.Capacity==0)
            {
                throw new ArgumentNullException("List can not be null or empty");
            }

            List<int> positions = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if ((int) list[i] == value) positions.Add(i + 1);
            }

            return positions;
        }

      }
}