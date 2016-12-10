using System;

namespace MaxMin
{
    //Because of the task of creating the unit tests to written methods,
    //Max() and Min() function are implemented with loops.
    //But searching max and min values of an array can be done by one row:
    //array.Max(), array.Min() - (with using LINQ).

    public class ArrayExtentions<T> where T : IComparable
    {
        public static T Max(T[] array) 
        {
            var max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public static T Min(T[] array)
        {
            var min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
}