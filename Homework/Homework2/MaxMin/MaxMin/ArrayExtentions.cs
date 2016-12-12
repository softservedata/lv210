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
            T max;

            if ((array.Length != 0))
            {
                max = array[0];

                for (var i = 1; i < array.Length; i++)
                {
                    if (array[i] != null)
                    {
                        if (array[i].CompareTo(max) > 0)
                        {
                            max = array[i];
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Data is not valid! Array cannot be empty or has null values!");
                    }                
                }
            }
            else
            {
                throw new ArgumentException("Data is not valid! Array cannot be empty or has null values!");
            }
            
            return max;
        }

        public static T Min(T[] array)
        {
            T min;

            if ((array.Length != 0))
            {
                min = array[0];

                for (var i = 1; i < array.Length; i++)
                {
                    if (array[i] != null)
                    {
                        if (array[i].CompareTo(min) < 0)
                        {
                            min = array[i];
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Data is not valid! Array cannot be empty or has null values!");
                    }
                }
            }
            else
            {
                throw new ArgumentException("Data is not valid! Array cannot be empty or has null values!");
            }

            return min;
        }
    }
}