using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SortedListUtils
    {
        public static List<int> FindPositions(SortedList sortedList, int value)
        {
            if (sortedList == null || sortedList.Capacity == 0)
            {
                throw new ArgumentNullException("List can not be null or empty");
            }

            List<int> positions = new List<int>();
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int) sortedList[i] == value) positions.Add(i);
            }

            return positions;
        }

        //Removes all elements of sorted list, which are greater than specified value
        public static void RemoveAllGreaterThan(SortedList sortedList, int upperBound)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                if ((int) sortedList.GetByIndex(i) > upperBound)
                {
                    sortedList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

